using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;
    public float speed = 5.0f;
    public float stopSpeed = -5.0f;
    private Rigidbody2D rb;
    private Vector2 touchStartPosition;
    private bool isDragging = false;
    private Vector2 movementDirection;
    private AudioSource walkSound;
    private bool isPlayingWalkSound = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            walkSound = GetComponent<AudioSource>(); 
            
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    isDragging = true;
                    //walkSound.Play();
                    touchStartPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    break;

                case TouchPhase.Ended:
                    isDragging = false;
                    //walkSound.Pause();
                    movementDirection = Vector2.zero;
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        //walkSound.Play();
                        Vector2 touchCurrentPosition = Camera.main.ScreenToWorldPoint(touch.position);
                        movementDirection = (touchCurrentPosition - touchStartPosition).normalized;
                        touchStartPosition = touchCurrentPosition;
                    }
                    break;
            }
        }

        AnimateMovement(movementDirection);
    }

    void FixedUpdate()
    {
        walkSound = GetComponent<AudioSource>();
        if (isDragging && movementDirection != Vector2.zero)
        {
            
            Vector2 newPosition = rb.position + movementDirection * speed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
            if (!isPlayingWalkSound && walkSound != null)
            {
                walkSound.Play();
                isPlayingWalkSound = true;
            }
        } 
        if (!isDragging && movementDirection == Vector2.zero) {
            walkSound.Pause();
            Vector2 newPosition = rb.position + movementDirection * stopSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
            if (isPlayingWalkSound && walkSound != null)
            {
                walkSound.Pause();
                isPlayingWalkSound = false;
            }
        }
    }

    void AnimateMovement(Vector2 direction)
    {
        if (animator != null)
        {
            if (direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}

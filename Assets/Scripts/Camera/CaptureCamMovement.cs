using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureCamMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float MoveSpeed = 2;
    public float StopSpeed = -2;
    //public GameObject Camera;
    private bool _moveRight;
    private bool _moveLeft;
    private bool _moveUp;
    private bool _moveDown;
    private Vector2 _movementDirection;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _movementDirection = Vector2.zero;
        _moveLeft = false;
        _moveRight = false;
        _moveUp = false;
        _moveDown = false;
    }

    public void PointerLeftPressed()
    {
        _moveLeft = true; 
    }

    public void PointerLeftUnpressed()
    {
        _moveLeft = false; 
    }

    public void PointerRightPressed()
    {
        _moveRight = true;
    }

    public void PointerRightUnpressed()
    {
        _moveRight = false;
    }

    public void PointerUpPressed()
    {
        _moveUp = true;
    }

    public void PointerUpUnpressed()
    {
        _moveUp = false;
    }

    public void PointerDownPressed()
    {
        _moveDown = true;
    }

    public void PointerDownUnpressed()
    {
        _moveDown = false;
    }

    // Update is called once per frame
    void Update()
    {
       MovePlayer();
    }

    private void MovePlayer()
    {
        if(_moveLeft) {
            _movementDirection = new Vector2(-1, 0);
            //_moveLeft = false;
        } else if (_moveRight) {
            _movementDirection = new Vector2(1, 0);
            //_moveRight = false;
        } else if (_moveUp) {
            _movementDirection = new Vector2(0, 1);
           // _moveUp = false;
        } else if (_moveDown) {
            _movementDirection = new Vector2(0, -1);
           // _moveDown = false;
        } else {
            _movementDirection = Vector2.zero;
        }
    }

    private void FixedUpdate() 
    {
        if (_movementDirection != Vector2.zero) 
        {
            Vector2 newPosition = rb.position + _movementDirection * MoveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
        } else {
            Vector2 newPosition = rb.position + _movementDirection * StopSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
        }
    }
    
}

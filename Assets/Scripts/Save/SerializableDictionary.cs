using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    //save the dict to lists
   [SerializeField] private List<TKey> keys = new List<TKey>();
   [SerializeField] private List<TValue> values = new List<TValue>();
   
   public void OnBeforeSerialize()
   {
    keys.Clear();
    values.Clear();
    Debug.Log("before serialize");
    foreach (KeyValuePair<TKey, TValue> pair in this)
    {
        keys.Add(pair.Key);
        Debug.Log(pair.Key.ToString());
        values.Add(pair.Value);
        Debug.Log(pair.Value.ToString());
    }
    //Debug.Log("no. of keys ("+ keys.Count + "), no. of values (" + values.Count + ")");
   }

   public void OnAfterDeserialize()
   {
    this.Clear();
    Debug.Log("after serialize");

    if(keys.Count != values.Count)
    {
        Debug.LogError("tried to deserialize a SerializableDictionary but the no. of keys ("+ keys.Count + ") does not match the no. of values (" + values.Count + ") so wrong");
    }

    for (int i = 0; i < keys.Count; i++)
    {
        this.Add(keys[i], values[i]);
        Debug.Log(keys[i].ToString());
        Debug.Log(values[i].ToString());
    }
   }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class BaseListSOSet<T> : ScriptableObject 
{
    [SerializeField]
    protected List<T> Items = new List<T>();

    public void Add(T item)
    {
        Items.Add(item);
    }

    public void Remove(T item)
    {
        if (Items.Contains(item))
            Items.Remove(item);
    }



}

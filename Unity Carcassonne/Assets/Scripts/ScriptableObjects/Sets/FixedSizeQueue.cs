using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class FixedSizeQueue<T> : ScriptableObject
{ 
    public Queue<T> queue = new Queue<T>();

    [SerializeField]
    protected IntVariable SizeLimit;
    
    public void Enqueue(T item)
    {
        queue.Enqueue(item);
        if (queue.Count > SizeLimit.Value)
            queue.Dequeue();
    }

    public T GetLast()
    {
        return queue.LastOrDefault();
    }

}

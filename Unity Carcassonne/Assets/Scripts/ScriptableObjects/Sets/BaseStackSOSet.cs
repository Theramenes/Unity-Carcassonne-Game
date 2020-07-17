using System.Collections.Generic;
using UnityEngine;

/*
 * Using List to build a Stack
 */
public abstract class BaseStackSOSet<T> : ScriptableObject
{
    [SerializeField]
    protected List<T> Items = new List<T>();

    public void Pop()
    {
        if (Items.Count > 0)
            Items.RemoveAt(Items.Count - 1);
    }

    public T Top()
    {
        if (Items.Count > 0)
            return Items[Items.Count - 1];

        return default(T);
    }

    public void Push(T item)
    {
        Items.Add(item);
    }

    public void CopyFromList(List<T> items)
    {
        Items = items;
    }

    /*
     * if the top item in Items is not available
     * randomly pick a item to replace the top item
     */
    public void Shuffle()
    {
        int tempIndex = Random.Range(0, Items.Count - 1);
        Swap(tempIndex, Items.Count - 1);
    }

    public void Swap(int indexA, int indexB)
    {
        T temp = Items[indexA];
        Items[indexA] = Items[indexB];
        Items[indexB] = temp;
    }

}

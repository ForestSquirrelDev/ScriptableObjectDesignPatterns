using UnityEngine;
using System.Collections.Generic;

public class RuntimeSet<T> : ScriptableObject
{
    private List<T> items = new List<T>();
    public List<T> Items => items;

    public void AddItem(T t)
    {
        if (!items.Contains(t))
            items.Add(t);
    }

    public void RemoveItem(T t)
    {
        if (items.Contains(t))
            items.Remove(t);
    }
}

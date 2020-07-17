using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class 实现 tile dictionary
 * 如需要用于替代ScriptableObject实现方式
 */

public class RuntimeTileDictionary
{
    [SerializeField]
    private Dictionary<Vector3, TileObject> tileDict;

    RuntimeTileDictionary()
    {
        tileDict = new Dictionary<Vector3, TileObject>();
    }

    public void Add(Vector3 vector, TileObject tileObject)
    {
        if (!tileDict.ContainsKey(vector))
            tileDict.Add(vector, tileObject);
    }

    public void Remove(Vector3 vector)
    {
        if (tileDict.ContainsKey(vector))
            tileDict.Remove(vector);
    }

    public bool FindTile(Vector3 vector)
    {
        return tileDict.ContainsKey(vector);
    }
}

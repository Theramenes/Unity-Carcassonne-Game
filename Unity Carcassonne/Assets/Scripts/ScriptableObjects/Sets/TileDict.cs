using System;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

/*
 * 笔记： 由于Dictionary没有自带序列化支持，所以每次都会清空
 * 当然因为正好运行时的Tile Dict不需要序列化 但这里的问题是同样也看不到Dictionary具体内容
 * 
 * 想要看到Dict的内容可以用另外一个辅助List 
 * 但是一旦用能够序列化的类型创建List 因为Scriptable Object的特性 List就被序列化了 不能在运行时使用
 * 所以是否用ScriptableObject来作为tile运行时存储 不能说绝对合适
 * 同时还考虑到网络的同步问题 是否应该用Class更为合适
 */
[CreateAssetMenu(fileName = "Tile Dictionary", menuName = "Scriptable Sets/Tile Dictionary")]
public class TileDict : ScriptableObject
{
    //public VectorList KeyList;
    //public List<String> ValueList = new List<string>();

    private Dictionary<Vector3, TileObject> Items = new Dictionary<Vector3, TileObject>();

    public void Add(Vector3 vector3, TileObject tile)
    {
        if (!Items.ContainsKey(vector3))
        {
            Items.Add(vector3, tile);
            //KeyList.Add(vector3);
            //ValueList.Add(tile.Tile.TileName);
        }
    }

    public void Remove(Vector3 vector3, TileObject tile)
    {
        if (Items.ContainsKey(vector3))
        {
            Items.Remove(vector3);
            //KeyList.Remove(vector3);
            //ValueList.Remove(tile.Tile.TileName);
        }
    }

    public bool FindTile(Vector3 vector3)
    {
        return Items.ContainsKey(vector3);
    }

    //public void OnBeforeSerialize()
    //{
    //    _keys.Clear();
    //    _values.Clear();

    //    foreach (var item in Items)
    //    {
    //        _keys.Add(item.Key);
    //        _values.Add(item.Value);
    //    }
    //}

    //public void OnAfterDeserialize()
    //{
    //    Items = new Dictionary<Vector3, TileObject>();

    //    for (int i = 0; i != Math.Min(_keys.Count, _values.Count); i++)
    //        Items.Add(_keys[i], _values[i]);
    //}

    //void OnGUI()
    //{
    //    foreach (var kvp in Items)
    //        GUILayout.Label("Key: " + kvp.Key + " value: " + kvp.Value);
    //}
}

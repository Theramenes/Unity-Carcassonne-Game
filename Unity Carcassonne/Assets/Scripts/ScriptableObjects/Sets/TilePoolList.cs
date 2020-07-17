using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Sets/Tile Pool")]
public class TilePoolList : BaseListSOSet<BaseTile>
{
    public BaseTile FindBaseTileViaName(string tileName)
    {
        for(int i = 0; i< Items.Count; i++)
        {
            if (Items[i].TileName == tileName)
                return Items[i];
        }
        return null;
    }
}

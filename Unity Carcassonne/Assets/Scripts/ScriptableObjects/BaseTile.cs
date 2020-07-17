using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Tile_", menuName = "Tiles/Tile")]
public class BaseTile : ScriptableObject
{
    public string TileName;
    public int TileIndex;

    [Header("Tile Boarder Features")]
    public BaseFeature Up;
    public BaseFeature Right;
    public BaseFeature Bottom;
    public BaseFeature Left;

    public List<BaseFeature> Features;

    [Header("Tile Material")]
    public Material TilemTerrainMaterial;

    public BaseFeature GetBoarder(int edgeIndex)
    {
        switch (edgeIndex)
        {
            case 0:
                return Up;
            case 1:
                return Right;
            case 2:
                return Bottom;
            case 3:
                return Left;
            default:
                return null;
        }
    }
}

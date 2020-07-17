using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedTileController : MonoBehaviour
{
    [Header("Tile Sets")]
    public TileDict PlacedTileDict;
    public TileDict CandidateTileDict;

    public TileVectorFixedQueue LastPlacedTileVectorQueue;
    public TileVectorFixedQueue CurrentPlacingTile;

    [Header("Tile Info")]
    public GameObject TilePrefab;
    public GameObject InitialTile;


    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Initialization()
    {
        PlacedTileDict.Add(InitialTile.transform.position, InitialTile.GetComponent<TileObject>());
        LastPlacedTileVectorQueue.Enqueue(InitialTile.transform.position);
    }

}

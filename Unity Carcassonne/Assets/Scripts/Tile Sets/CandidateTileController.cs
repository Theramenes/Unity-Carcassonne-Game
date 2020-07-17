using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CandidateTileController : MonoBehaviour
{
    [Header("Tile Sets")]
    public TileDict CandidateTileDict;
    public TileDict PlacedTileDict;
    
    public TileVectorFixedQueue LastPlacedTileVectorQueue;
    public TileVectorFixedQueue CurrentPlacingTile;

    public BaseTile currentPlacingTile;

    [Header("Tile Info")]
    public GameObject TilePrefab;
    public Material TilePlaceableMaterial;

    [Header("")]
    public PlayerClickInputInfo PlayerClickInfo;

    private float tileSize;
    private Vector3[] offsets;

    // TODO:

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    } 

    // Update is called once per frame
    void Update()
    {
        
    }


    private void Initialization()
    {
        tileSize = TilePrefab.GetComponent<MeshFilter>().sharedMesh.bounds.size.x;
        offsets = new[] { new Vector3(0f, 0f, tileSize),
                            new Vector3(tileSize, 0f, 0f),
                            new Vector3(0f, 0f, -tileSize),
                            new Vector3(-tileSize, 0f, 0f)};
        Debug.Log("Tile Size:" + tileSize);
    }

    public void TilePreplaceClickResponse()
    {
        if (ValidatePreplacePosition())
        {
            Debug.Log("Click Position is Available.");
            TilePreplace();

        }
        Debug.Log("Click Position is not Available.");
    }

    void TilePreplace()
    {

    }

    bool ValidatePreplacePosition()
    {
        Vector3 refactoredPosition = new Vector3((int)(PlayerClickInfo.MouseClickPosition.x / tileSize) * 10f, 
                                                0f,
                                                (int)(PlayerClickInfo.MouseClickPosition.z / tileSize) * 10f);
        Debug.Log("Click Position converted to Tile Positions:" + refactoredPosition);
        return CandidateTileDict.FindTile(refactoredPosition);
    }

    void CheckAvailableCandidateTiles()
    {

    }

    /*
     * 在新放置Tile周围创建新的Tiles
     */
    public void CreateCandidateTiles()
    {
        Vector3 vector = LastPlacedTileVectorQueue.GetLast();
        for (int i = 0; i < offsets.Length; i++)
            CreateNewTile(vector + offsets[i]);

    }

    void CreateNewTile(Vector3 vector)
    {
        if (CandidateTileDict.FindTile(vector))
            return;

        GameObject newTile = (GameObject)Instantiate(TilePrefab, vector, transform.rotation);
        newTile.transform.parent = this.transform;

        newTile.GetComponent<MeshRenderer>().material = TilePlaceableMaterial;
        newTile.SetActive(true);

        TileObject tileObject = newTile.GetComponent<TileObject>();
        tileObject.PlacedTileDict = PlacedTileDict;
        tileObject.CandidateTileDict = CandidateTileDict;
        
        CandidateTileDict.Add(vector, tileObject);
    }
}

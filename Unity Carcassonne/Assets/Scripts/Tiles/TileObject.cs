using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TileObject : MonoBehaviour
{
    public BaseTile Tile;
    public TileDict PlacedTileDict;
    public TileDict CandidateTileDict;

    [Header("Tile Data")]

    [SerializeField]
    private Vector3 tilePosition;

    private Transform tileTransform;
    private bool isPlaced = false;
    private bool isTileAssgined = false;

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        
    }

    public BaseFeature GetEdge(int edgeIndex)
    {
        float rotation = tileTransform.eulerAngles.y;
        int convertedEdgeIndex = (edgeIndex - (int)(rotation / 90)) % 4;
        return Tile.GetBoarder(convertedEdgeIndex);
    }

    void Initialization()
    {
        tileTransform = transform;
        tilePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }

    void UpdateMaterial()
    {

    }

}

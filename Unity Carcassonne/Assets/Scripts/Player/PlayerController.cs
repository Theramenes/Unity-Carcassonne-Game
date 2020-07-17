using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [Header("Tile Stack")]
    public TilePlayerStack TileStack;
    public BaseTile currentPlacingTile;

    [Header("Player Input/Event")]
    public PlayerClickInputInfo PlayerTilePlaceInfo;
    public UnityEvent OnPlayerMouseClick;

    [SerializeField]
    private bool isPlayerTurn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerClickPosition();
    }

    void GetPlayerClickPosition()
    {
        // Click only available in player's turn


        Vector3 clickPosition = Vector3.zero;

        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray;
        float enter;

        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out enter))
            {
                clickPosition = ray.GetPoint(enter);
            }

            PlayerTilePlaceInfo.MouseClickPosition = clickPosition;
            Debug.Log("Player Tile Placing Click Position:" + clickPosition);
            if (isPlayerTurn)
                OnPlayerMouseClick.Invoke();
        }
    }

    void GetTopTileFromStack()
    {
        currentPlacingTile = TileStack.Top();
    }

    /*
     * 开始玩家回合
     * 同时把当前地块从stack取出 以供CandidateTile进行判断
     */
    public void SetPlayerTurnStart()
    {
        isPlayerTurn = true;
        GetTopTileFromStack();
    }

    public void SetPlayerTurnEnd()
    {
        isPlayerTurn = false;
    }
}

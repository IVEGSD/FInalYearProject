using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardM : MonoBehaviour {
	public static BoardM Instance{ set; get;}
	private bool[,] allowedMoves{ set; get;}

	public Chessman[,] Chessmans{ set; get;}
	private Chessman selectedChessman;
    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = 0.5f;

    private int selectionX = -1;
    private int selectionY = -1;

    public List<GameObject> chessmanPrefabs;
	private List<GameObject> activeChessman = new List<GameObject>(); 
    // Use this for initialization

	private Quaternion orientation = Quaternion.Euler(0,180,0);

	public bool isWhiteTurn = true;
	private void Start(){
		Instance = this;
		SpawnAllChessmans ();
	}

    // Update is called once per frame
    private void Update()
    {
        UpdateSelection();
        DrawChessboard();

		if (Input.GetMouseButtonDown (0)) {
			if (selectionX >= 0 && selectionY >= 0) {
				if(selectedChessman ==null){
					SelectChessman(selectionX,selectionY);
				}
				else{
					MoveChessman(selectionX,selectionY);
				}
			}
		}
        
    }
	private void SelectChessman(int x, int y){
		if (Chessmans [x, y] == null)
			return;
		if (Chessmans [x, y].isWhite != isWhiteTurn)
			return;

		allowedMoves = Chessmans [x, y].PossibleMove ();
		selectedChessman = Chessmans [x, y];
		BoardHighlights.Instance.HighlightAllowedMoves (allowedMoves);
	}
	private void MoveChessman(int x, int y){
		if (allowedMoves[x,y]) {
			Chessmans [selectedChessman.CurrentX, selectedChessman.CurrentY] = null;
			selectedChessman.transform.position = GetTileCenter (x, y);
			selectedChessman.SetPosition (x, y);
			Chessmans [x, y] = selectedChessman;
			isWhiteTurn = !isWhiteTurn;
		}
		BoardHighlights.Instance.Hidehighlights ();
		selectedChessman = null;
	}

    private void DrawChessboard()
    {
        Vector3 widthLing = Vector3.right * 8;
        Vector3 heigthLine = Vector3.forward * 8;

        for (int i = 0; i <= 8; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine (start,  start + widthLing);
            for (int j = 0; j <= 8; j++)
            {
                start = Vector3.right * j;
                Debug.DrawLine (start,  start + heigthLine);
            }
        }
        if(selectionX >=0 && selectionY >= 0)
        {
            Debug.DrawLine(
                Vector3.forward * selectionY + Vector3.right * selectionX,
                Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1));

            Debug.DrawLine(
    Vector3.forward * (selectionY + 1) + Vector3.right * selectionX,
    Vector3.forward * selectionY  + Vector3.right * (selectionX + 1));
        }

    }
    private void UpdateSelection()
    {
        if (!Camera.main)
            return;
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("Plane")))
        {
            selectionX = (int)hit.point.x;
            selectionY = (int)hit.point.z;
           
        }
        else
        {
            selectionX = -1;
            selectionY = -1;
        }

    }

	private void SpawnChessman(int index, int x,int y){
		GameObject go = Instantiate (chessmanPrefabs [index], GetTileCenter(x,y),orientation) as GameObject;
		go.transform.SetParent (transform);
		Chessmans [x, y] = go.GetComponent<Chessman> ();
		Chessmans [x, y].SetPosition (x, y);
		activeChessman.Add (go);

	}
	private void SpawnAllChessmans(){
		activeChessman = new List<GameObject> ();
		Chessmans = new Chessman[8, 8];
		SpawnChessman (0, 3,0);
		SpawnChessman (1, 7,0);
		SpawnChessman (1, 4,0);
		SpawnChessman (2, 4,6);
		//SpawnChessman (0, GetTileCenter(7.0));
		//SpawnChessman (0, GetTileCenter(4.0));
	}
	private Vector3 GetTileCenter(int x, int y){
		Vector3 origin = Vector3.zero;
		origin.x += (TILE_SIZE * x) + TILE_OFFSET;
		origin.z += (TILE_SIZE * y) + TILE_OFFSET;
		return origin;
	}
}

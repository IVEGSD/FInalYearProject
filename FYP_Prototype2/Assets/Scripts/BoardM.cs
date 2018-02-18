using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class BoardM : MonoBehaviour {
	public static BoardM Instance{ set; get;}
	private bool[,] allowedMoves{ set; get;}

	public Chessman[,] Chessmans{ set; get;}
	public static Chessman selectedChessman;
    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = 0.5f;
    Button btn;
    private int selectionX = -1;
    private int selectionY = -1;
	private int checkRound = 1;
    public List<GameObject> chessmanPrefabs;
	private List<GameObject> activeChessman = new List<GameObject>();
    // Use this for initialization
    private Material previousMat;
    System.Random rnd = new System.Random();
    public static bool whetherMove = false;
	private Quaternion orientation = Quaternion.Euler(0,180,0);
    public Button moveButton;
    public static bool isWhiteTurn = true,isNPC = false;
    bool clickMap = true;
    int NPCPositiontX1 = 6, NPCPositiontY1 = 0;
	private void Start(){
		Instance = this;
		SpawnAllChessmans ();
        //Button abtn = yourButton.GetComponent<Button>();
        btn = moveButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    private void Update()
    {
        
        UpdateSelection();
        DrawChessboard();
        Vector3 pos = moveButton.transform.position;

        if (Input.GetMouseButtonDown (0)&& pos.x == 100) {
			if (selectionX >= 0 && selectionY >= 0) {
                if(selectionX == NPCPositiontX1&& selectionY == NPCPositiontY1)
                {
                    isNPC = true;
                }
                else
                {
                    isNPC = false;
                }
				if(selectedChessman ==null){
                    TurnEnd.click = false;
                    
                    SelectChessman(selectionX,selectionY);
                    //whetherMove = false;
                }
				else{

                    MoveChessman(selectionX,selectionY);
                    whetherMove = false;

                }
			}
		}


        if (TurnEnd.round > checkRound) {
            //Chessmans[6, 0].SetPosition(5, 5);
            whetherMove = true;
            SelectChessman(NPCPositiontX1, NPCPositiontY1);
            
            int rX = rnd.Next(7);
            int rY = rnd.Next(7);
            while(allowedMoves[rX, rY]==false||Chessmans[rX,rY]!=null)
            {
                rX = rnd.Next(7);
                rY = rnd.Next(7);
            }
            NPCPositiontX1 = rX;
            NPCPositiontY1 = rY;
            MoveChessman(rX, rY);
            whetherMove = false;

            for (int x = 0; x < 8; x++) {
				for (int y = 0; y < 8; y++) {
					if (Chessmans [x, y] != null) {
						Chessmans [x, y].isWhite = true;
                        //;
                        //whetherMove = true;
                    }
				}
			}
		}
		checkRound = TurnEnd.round;


    }
	private void SelectChessman(int x, int y){
		if (Chessmans [x, y] == null)
			return;
        //if (Chessmans [x, y].isWhite != isWhiteTurn)
        //return;


        //if (whetherMove == true)

      
        allowedMoves = Chessmans[x, y].PossibleMove();
        selectedChessman = Chessmans[x, y];
        //previousMat = selectedChessman.GetComponent<MeshRenderer>().material;
        //selectedMat.mainTexture = previousMat.mainTexture;
        //selectedChessman.GetComponent<MeshRenderer>().material = selectedMat;
        // BoardHighlights.Instance.HighlightAllowedMoves(allowedMoves);
        
    }
	private void MoveChessman(int x, int y){
		if (allowedMoves[x,y]&& whetherMove) {
			Chessman c = Chessmans [x, y];
			if (c != null) {
				selectedChessman = null;
                //whetherMove = false;
                //Chessmans [x, y] = Chessmans [selectedChessman.CurrentX, selectedChessman.CurrentY];
            } else {
				Chessmans [selectedChessman.CurrentX, selectedChessman.CurrentY] = null;
				selectedChessman.transform.position = GetTileCenter (x, y);
				selectedChessman.SetPosition (x, y);
				Chessmans [x, y] = selectedChessman;
				selectedChessman.isWhite = false;
			}//isWhiteTurn = !isWhiteTurn;
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
			//Vector3 pos = yourButton.transform.position;
            selectionX = (int)hit.point.x;
            selectionY = (int)hit.point.z;
			//pos.x = selectionX;
			//pos.y = selectionY;
			//yourButton.transform.position = pos;
           
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
        SpawnChessman(3, 6, 0);
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
    private void TaskOnClick()
    {

        BoardHighlights.Instance.HighlightAllowedMoves(allowedMoves);
        whetherMove = true;
    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
	public static BoardManager Instance{set;get;}
	public bool[,] allowedMoves{set;get;}
	
	public ChessPieces[,] ChessPieces;
	private ChessPieces selectedPiece;
	
   	private const float TILE_SIZE = 5f;
   	private const float TILE_OFFSET = 2.5f;
   
   	private int selectionX = -50;
   	private int selectionZ = -50;
   	
   	public List<GameObject> piecePrefabs;
   	public List<GameObject> activePieces;
   	
   	public bool isWhiteTurn = true;
   	
   	private Quaternion orientation = Quaternion.Euler(0,180,0);
   	private Quaternion blackOrientation = Quaternion.Euler(0,0,0);
   	
   	private void Start()
   	{
   		SpawnAllPieces();
   		Instance = this;
		//print(ChessPieces[0,0]);
   	}
   
   	private void Update()
   	{
		UpdateSelection();
   		
   		if(Input.GetMouseButtonDown(0)){
   			if (selectionX != -50 && selectionZ != -50){
   				if(selectedPiece == null){
   					SelectPiece(selectionX,selectionZ);
   				}
   				else{
   					MovePiece(selectionX,selectionZ);
   				}
   			}
   		}
   		
  	}
  	
  	private void SelectPiece(int x, int z)
  	{
  		x = convertToArrayElement (x);
  		z = convertToArrayElement (z);
  		if(ChessPieces[x,z] == null)
  			return;
  		if(ChessPieces[x,z].isWhite != isWhiteTurn)
  			return;
  		
  		bool hasMoves = false;
  		allowedMoves = ChessPieces[x,z].PossibleMove();
  		for(int i = 0; i < 8; i++)
  			for(int j = 0; j < 8; j++)
  				if(allowedMoves[i, j])
  					hasMoves = true;
  		
  		if(!hasMoves)
  			return;
  					
  		allowedMoves = 	ChessPieces[x,z].PossibleMove();
  		selectedPiece = ChessPieces[x,z];
  		BoardHighlights.Instance.HighlightAllowedMoves(allowedMoves);
		print(selectedPiece);
  	}
  	
  	private void MovePiece(int x, int z)
  	{
  		int a = convertToArrayElement (x);
  		int b = convertToArrayElement (z);
  		if(allowedMoves[a,b]){
  		
  			ChessPieces c = ChessPieces [a,b];
  			if(c != null && c.isWhite != isWhiteTurn)
  			{
  				//Capture a piece
  				if(c.GetType() == typeof(King)){
  					EndGame();
  					return;
  				}
  				activePieces.Remove(c.gameObject);
  				Destroy(c.gameObject);
  				
  				
  			}
			
			//THE FOLLOWING IS WORKING CODE FOR OLD MOVEMENT METHOD, DO NOT DELETE
			//int oldX = convertToArrayElement(selectedPiece.CurrentX);
			//int oldZ = convertToArrayElement(selectedPiece.CurrentZ);

			//ChessPieces[a,b] = ChessPieces[oldX, oldZ];	
  			
			//ChessPieces[oldX, oldZ].transform.position = new Vector3(x,selectedPiece.transform.position.y,z);

			//ChessPieces[a,b].SetPosition(x,z);
			//ChessPieces[oldX, oldZ] = null;

  			//isWhiteTurn = !isWhiteTurn;

			//New Movement
			int oldX = convertToArrayElement(selectedPiece.CurrentX);
			int oldZ = convertToArrayElement(selectedPiece.CurrentZ);

			ChessPieces[a,b] = ChessPieces[oldX, oldZ];	
  			
			ChessPieces[oldX, oldZ].targetPosition = new Vector3(x,selectedPiece.transform.position.y,z);

			ChessPieces[a,b].SetPosition(x,z);
			ChessPieces[oldX, oldZ] = null;

  			isWhiteTurn = !isWhiteTurn;

			
  		}
  		
  		BoardHighlights.Instance.Hidehighlights();
  		selectedPiece = null;
		allowedMoves = null;
  	}
   
  	 private void UpdateSelection()
   	{
   		if(!Camera.main)
   			return;
   		
   		RaycastHit hit;
   		if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f, LayerMask.GetMask("ChessPlane"))){
   			selectionX = (int)hit.point.x;
   			selectionZ = (int)hit.point.z;
   			(selectionX, selectionZ) = RoundSelection(selectionX, selectionZ);   			
   		}
   		else{
   			selectionX = -50;
   			selectionZ = -50;
   		}
   	}
   
   	private void DrawSelection()
  	{
   		if(selectionX >= -40 && selectionZ >= -40)
   		{
   			Debug.DrawLine(
   				Vector3.forward * selectionZ + Vector3.right * selectionX,
   				Vector3.forward * (selectionZ + 10) + Vector3.right * (selectionX + 10));
   				
   			Debug.DrawLine(
   				Vector3.forward * (selectionZ + 10) + Vector3.right * selectionX,
   				Vector3.forward * selectionZ + Vector3.right * (selectionX + 10));
   		}
   	}
   	
   	private void SpawnPiece(int index, int x, int z, float y)
   	{
   		GameObject go = Instantiate(piecePrefabs[index], new Vector3(x,y,z), orientation) as GameObject;
   		go.transform.SetParent(transform);
   		int a = convertToArrayElement(x);
   		int b = convertToArrayElement(z);
   		ChessPieces[a,b] = go.GetComponent<ChessPieces> ();
   		ChessPieces[a,b].SetPosition(x,z);
   		activePieces.Add(go);
   	}
   	
   	private void SpawnBlackPiece(int index, int x, int z, float y)
   	{
   		GameObject go = Instantiate(piecePrefabs[index], new Vector3(x,y,z), blackOrientation) as GameObject;
   		go.transform.SetParent(transform);
   		int a = convertToArrayElement(x);
   		int b = convertToArrayElement(z);
   		ChessPieces[a,b] = go.GetComponent<ChessPieces> ();
   		ChessPieces[a,b].SetPosition(x,z);
   		activePieces.Add(go);
   	}
   	
   	private int convertToArrayElement (int x)
   	{
   		if(x == -35){
   			return 7;
   		}
   		else if(x == -25){
   			return 6;
   		}
   		else if(x == -15){
   			return 5;
   		}
   		else if(x == -5){
   			return 4;
   		}
   		else if(x == 5){
   			return 3;
   		}
   		else if(x == 15){
   			return 2;
   		}
   		else if(x == 25){
   			return 1;
   		}
   		else if(x == 35){
   			return 0;
   		}
   		else{
   			return 0;
   		}
   		
   	}
   	
   	private void SpawnAllPieces()
   	{
   		ChessPieces = new ChessPieces[8,8];
   		
   		//spawn white pieces
   			//king
   			SpawnPiece(5, -5, 35, (float)3.8); 			
   			//queen
   			SpawnPiece(4, 5, 35, (float)3.8);
   			//rooks
   			SpawnPiece(3, -35, 35, 3);
   			SpawnPiece(3, 35, 35, 3);
   			//bishops
   			SpawnPiece(2, -15, 35, (float)3);
   			SpawnPiece(2, 15, 35, (float)3);
   			//knights
   			SpawnPiece(1, -25, 35, 0);
   			SpawnPiece(1, 25, 35, 0);
   			//pawns
   			int x = -35;
   			for (int i = 0; i < 8; i++){
   				SpawnPiece (0, x, 25, 0);
   				x += 10;
   			}
   		//spawn black pieces
   			//king
   			SpawnBlackPiece(11, -5, -35, 0); 
   			//queen
   			SpawnBlackPiece(10, 5, -35, (float)3.5);
   			//rooks
   			SpawnBlackPiece(9, -35, -35, (float)3.5);
   			SpawnBlackPiece(9, 35, -35, (float)3.5);
   			//bishops
   			SpawnBlackPiece(8, -15, -35, 2);
   			SpawnBlackPiece(8, 15, -35, 2);
   			//knights
   			SpawnBlackPiece(7, -25, -35, 0);
   			SpawnBlackPiece(7, 25, -35, 0);
   			//pawns
   			x = -35;
   			for (int i = 0; i < 8; i++){
   				SpawnBlackPiece (6, x, -25, (float)2.5);
   				x += 10;
   			}
   	}
   
   	private (int, int) RoundSelection(int x, int z)
   	{
   		//round the value of x
   		if (x >= -40 && x < -30){
   			x = -35;
   		}
   		else if (x >= -30 && x < -20){
   			x = -25;
   		}
   		else if (x >= -20 && x < -10){
   			x = -15;
   		}
   		else if (x >= -10 && x < 0){
   			x = -5;
   		}
   		else if (x >= 0 && x < 10){
   			x = 5;
   		}
   		else if (x >= 10 && x < 20){
   			x = 15;
   		}
   		else if (x >= 20 && x < 30){
   			x = 25;
   		}
   		else if (x >= 30 && x <= 40){
   			x = 35;
   		}
   		
   		//Round the value of z
   		if (z >= -40 && z < -30){
   			z = -35;
   		}
   		else if (z >= -30 && z < -20){
   			z = -25;
   		}
   		else if (z >= -20 && z < -10){
   			z = -15;
   		}
   		else if (z >= -10 && z < 0){
   			z = -5;
   		}
   		else if (z >= 0 && z < 10){
   			z = 5;
   		}
   		else if (z >= 10 && z < 20){
   			z = 15;
   		}
   		else if (z >= 20 && z < 30){
   			z = 25;
   		}
   		else if (z >= 30 && z <= 40){
   			z = 35;
   		}  		
   		
   		return (x, z);
   	}
   	
   	private void EndGame()
   	{
   		if(isWhiteTurn)
   			Debug.Log("White Team Wins");
   		else
   			Debug.Log("Black Team Wins");
   		foreach(GameObject go in activePieces)
   			Destroy(go);
   			
   		isWhiteTurn = true;
   		BoardHighlights.Instance.Hidehighlights();
   		SpawnAllPieces();
   		
   	}
   
  
}

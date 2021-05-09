using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPieces
{

    public override bool[,] PossibleMove()
    {
    	bool[,] r = new bool[8,8];
    	ChessPieces c, c2;
    	
    	//White team move
    	if (isWhite)
    	{
    		int x = convertToArrayElement(CurrentX);
    		int z = convertToArrayElement(CurrentZ);
    		
    		//Diagonal Left
    		if(x != 0 && z != 7){
    			c = BoardManager.Instance.ChessPieces[x - 1 , z + 1];
    			if (c != null && !c.isWhite)
    				r[x - 1, z + 1] = true;
    		}
    		//Diagonal Right
    		if(x != 7 && z != 7){
    			c = BoardManager.Instance.ChessPieces[x + 1 , z + 1];
    			if (c != null && !c.isWhite)
    				r[x + 1, z + 1] = true;
    		}
    		//Middle
    		if (z != 7){
    			c = BoardManager.Instance.ChessPieces[x, z + 1];
    			if(c == null)
    				r[x, z + 1] = true;
    		}
    		
    		//Middle First Move
    		if (z == 1){
    			c = BoardManager.Instance.ChessPieces[x, z + 1];
    			c2 = BoardManager.Instance.ChessPieces[x, z + 2]; 
				if (c == null && c2 == null){
					r[x,z+2] = true;
				}
    		}
    	}
    	else{
    		int x = convertToArrayElement(CurrentX);
    		int z = convertToArrayElement(CurrentZ);
    		
    		//Diagonal Left
    		if(x != 0 && z != 0){
    			c = BoardManager.Instance.ChessPieces[x - 1 , z - 1];
    			if (c != null && c.isWhite)
    				r[x -1, z - 1] = true;
    		}
    		//Diagonal Right
    		if(x != 7 && z != 0){
    			c = BoardManager.Instance.ChessPieces[x + 1 , z - 1];
    			if (c != null && c.isWhite)
    				r[x + 1, z - 1] = true;
    		}
    		//Middle
    		if (z != 0){
    			c = BoardManager.Instance.ChessPieces[x, z - 1];
    			if(c == null)
    				r[x, z - 1] = true;
    		}
    		
    		//Middle First Move
    		if (z == 6){
    			c = BoardManager.Instance.ChessPieces[x, z - 1];
    			c2 = BoardManager.Instance.ChessPieces[x, z - 2]; 
				if (c == null && c2 == null){
					r[x,z-2] = true;
				}
    		}
    	}
    	
    	
    	return r;
    }
}

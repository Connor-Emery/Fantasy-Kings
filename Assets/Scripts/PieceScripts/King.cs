using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPieces
{

	public override bool[,] PossibleMove()
    {
    	bool[,] r = new bool[8,8];
    	
    	ChessPieces c;
    	int i, j;
    	
    	int x = convertToArrayElement(CurrentX);
    	int z = convertToArrayElement(CurrentZ);
    	
    	//Forward
    	i = x - 1;
    	j = z + 1;
    	if(z != 7){
    		for(int k = 0; k < 3; k++){
    			if (i >= 0 || i < 8){
    				c = BoardManager.Instance.ChessPieces[i,j];
    				if( c == null)
    					r[i,j] = true;
    				else if (isWhite != c.isWhite)
    					r[i,j] = true;
    			}
    			
    			i++;
    		}
    	}
    	
    	//Back
    	i = x - 1;
    	j = z - 1;
    	if(z != 0){
    		for(int k = 0; k < 3; k++){
    			if (i >= 0 || i < 8){
    				c = BoardManager.Instance.ChessPieces[i,j];
    				if( c == null)
    					r[i,j] = true;
    				else if (isWhite != c.isWhite)
    					r[i,j] = true;
    			}
    			
    			i++;
    		}
    	}
    	
    	i = x;
    	j = z;
    	//Left
    	if(x != 0){
    		c = BoardManager.Instance.ChessPieces[i - 1,j];
    		if (c == null)
    			r[x - 1, z] = true;
    		else if(isWhite != c.isWhite)
    			r[x -1, z] = true;
    	}
    	
    	//Right
    	if(x != 7){
    		c = BoardManager.Instance.ChessPieces[i + 1,j];
    		if (c == null)
    			r[x + 1, z] = true;
    		else if(isWhite != c.isWhite)
    			r[x + 1, z] = true;
    	}
    	
    	return r;
    }
}

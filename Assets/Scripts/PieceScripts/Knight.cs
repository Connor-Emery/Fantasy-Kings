using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPieces
{

 	public override bool[,] PossibleMove()
    {
    	bool [,] r = new bool[8,8];
    	
    	int x = convertToArrayElement(CurrentX);
    	int z = convertToArrayElement(CurrentZ);
    	
    	//Up 2 Left 1
    	KnightMove(x-1,z+2, ref r);
    	
    	//Up 2 Right 1
    	KnightMove(x+1,z+2, ref r);
    	
    	//Left 2 Up 1
    	KnightMove(x-2,z+1, ref r);
    	
    	//Right 2 Up 1
    	KnightMove(x+2,z+1, ref r);
    	
    	//Down 2 Left 1
    	KnightMove(x-1,z-2, ref r);
    	
    	//Down 2 Right 1
    	KnightMove(x+1,z-2, ref r);
    	
    	//Left 2 Down 1
    	KnightMove(x-2,z-1, ref r);
    	
    	//Right 2 Down 1
    	KnightMove(x+2,z-1, ref r);
    	
    	return r;
    }
    
    public void KnightMove(int x, int z, ref bool[,] r)
    {
    	ChessPieces c;
    	if (x >= 0 && x < 8 && z >= 0 && z < 8){
    		c = BoardManager.Instance.ChessPieces[x, z];
    		if (c == null)
    			r [x,z] = true;
    		else if (isWhite != c.isWhite){
    			r[x,z] = true;
    		}
    	}
    }
}

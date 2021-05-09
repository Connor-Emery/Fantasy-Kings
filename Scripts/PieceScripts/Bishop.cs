using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessPieces
{

	public override bool[,] PossibleMove()
    {
    	bool[,] r = new bool[8,8];
    	
    	ChessPieces c;
    	int i, j;
    	
    	int x = convertToArrayElement(CurrentX);
    	int z = convertToArrayElement(CurrentZ);
    	
    	//Top Left
    	i = x;
    	j = z;
    	while(true)
    	{
    		i--;
    		j++;
    		if(i < 0 || j >= 8)
    			break;
    			
    		c = BoardManager.Instance.ChessPieces[i,j];
    		if (c == null)
    			r[i,j] = true;
    		else{
    			if(isWhite != c.isWhite)
    				r[i,j] = true;
    			break;
    		}
    	}
    	
    	//Top Right
    	i = x;
    	j = z;
    	while(true)
    	{
    		i++;
    		j++;
    		if(i >= 8 || j >= 8)
    			break;
    			
    		c = BoardManager.Instance.ChessPieces[i,j];
    		if (c == null)
    			r[i,j] = true;
    		else{
    			if(isWhite != c.isWhite)
    				r[i,j] = true;
    			break;
    		}
    	}
    	
    	//Bottom Left
    	i = x;
    	j = z;
    	while(true)
    	{
    		i--;
    		j--;
    		if(i < 0 || j < 0)
    			break;
    			
    		c = BoardManager.Instance.ChessPieces[i,j];
    		if (c == null)
    			r[i,j] = true;
    		else{
    			if(isWhite != c.isWhite)
    				r[i,j] = true;
    			break;
    		}
    	}
    	
    	//Bottom Right
    	i = x;
    	j = z;
    	while(true)
    	{
    		i++;
    		j--;
    		if(i >= 8 || j < 0 )
    			break;
    			
    		c = BoardManager.Instance.ChessPieces[i,j];
    		if (c == null)
    			r[i,j] = true;
    		else{
    			if(isWhite != c.isWhite)
    				r[i,j] = true;
    			break;
    		}
    	}
    	
    	return r;
    }
}

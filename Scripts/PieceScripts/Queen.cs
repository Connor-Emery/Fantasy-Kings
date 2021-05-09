using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPieces
{

    public override bool[,] PossibleMove()
    {
    	bool[,] r = new bool[8,8];
    	ChessPieces c;
    	int i, j;
    	
    	int x = convertToArrayElement(CurrentX);
    	int z = convertToArrayElement(CurrentZ);
    	
    	//Right
    	i = x;
    	while(true){
    		i++;
    		if (i >= 8)
    			break;
    		
    		c = BoardManager.Instance.ChessPieces[i,z];
    		if (c == null)
    			r [i,z] = true;
    		else{
    			if(c.isWhite != isWhite)
    				r[i,z] = true;
    			break;
    		}
    	}
    	
    	//Left
    	i = x;
    	while(true){
    		i--;
    		if (i < 0)
    			break;
    		
    		c = BoardManager.Instance.ChessPieces[i,z];
    		if (c == null)
    			r [i,z] = true;
    		else{
    			if(c.isWhite != isWhite)
    				r[i,z] = true;
    			break;
    		}
    	}
    	
    	//forward
    	i = z;
    	while(true){
    		i++;
    		if (i >= 8)
    			break;
    		
    		c = BoardManager.Instance.ChessPieces[x,i];
    		if (c == null)
    			r [x,i] = true;
    		else{
    			if(c.isWhite != isWhite)
    				r[x,i] = true;
    			break;
    		}
    	}
    	
    	//backwards
    	i = z;
    	while(true){
    		i--;
    		if (i < 0)
    			break;
    		
    		c = BoardManager.Instance.ChessPieces[x,i];
    		if (c == null)
    			r [x,i] = true;
    		else{
    			if(c.isWhite != isWhite)
    				r[x,i] = true;
    			break;
    		}
    	}
    	
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

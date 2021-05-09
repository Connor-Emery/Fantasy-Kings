using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardHighlights : MonoBehaviour
{
    public static BoardHighlights Instance{set;get;}
    
    public GameObject highlightPrefab;
    private List<GameObject> highlights;
    
    private void Start()
    {
    	Instance = this;
    	highlights = new List<GameObject>();
    }
    
    private GameObject GetHighlightObject()
    {
    	GameObject go = highlights.Find(g => !g.activeSelf);
    	
    	if (go == null){
    		go = Instantiate(highlightPrefab);
    		highlights.Add(go);
    	}
    	
    	return go;
    }
    
    public void HighlightAllowedMoves(bool[,] moves)
    {
    	for(int i = 0; i<8; i++){
    		for(int j = 0; j<8; j++){
    			if (moves[i,j]){
    				int a = convertToWorldPosition(i);
    				int b = convertToWorldPosition(j);
    				GameObject go = GetHighlightObject();
    				go.SetActive(true);
    				go.transform.position = new Vector3(a,(float)0.001,b);
    			}
    		}
    	}
    }
    
    public void Hidehighlights()
    {
    	foreach(GameObject go in highlights)
    		go.SetActive(false);
    }
    
    private int convertToWorldPosition (int x)
   	{
   		if(x == 7){
   			return -35;
   		}
   		else if(x == 6){
   			return -25;
   		}
   		else if(x == 5){
   			return -15;
   		}
   		else if(x == 4){
   			return -5;
   		}
   		else if(x == 3){
   			return 5;
   		}
   		else if(x == 2){
   			return 15;
   		}
   		else if(x == 1){
   			return 25;
   		}
   		else if(x == 0){
   			return 35;
   		}
   		else{
   			return 0;
   		}
   		
   	}
    
}

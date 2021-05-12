using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPieces : MonoBehaviour
{
    public int CurrentX{set;get;}
    public int CurrentZ{set;get;}
    public bool isWhite;

	public Vector3 targetPosition;
	public Animator anim;

	private Quaternion facingDirection;

	private void Start(){
		targetPosition = transform.position;
		anim = GetComponent<Animator>();
		facingDirection = Quaternion.LookRotation(transform.forward);
	}

	private void Update(){

			transform.position = Vector3.MoveTowards(transform.position, targetPosition, 10*Time.deltaTime);
			if (targetPosition != transform.position){
				Vector3 direction = targetPosition - transform.position;
				Quaternion rotation = Quaternion.LookRotation(direction);
				transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 2*Time.deltaTime);
				anim.SetBool("isWalking", true);
			}
			else{
				anim.SetBool("isWalking", false);
				transform.rotation = Quaternion.Lerp(transform.rotation, facingDirection, 2*Time.deltaTime);
			}
		
	}

    public void SetPosition(int x, int z)
    {
    	CurrentX = x;
    	CurrentZ = z;
    }
    
    public virtual bool[,] PossibleMove()
    {
    	return new bool[8,8];
    }
    
    public int convertToArrayElement (int x)
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
    
}

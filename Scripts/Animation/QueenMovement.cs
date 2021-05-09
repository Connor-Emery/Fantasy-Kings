using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenMovement : MonoBehaviour
{

	Animator animator;
    Rigidbody rb;
    public bool isWalking;

	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 velocity = rb.velocity;
        if (velocity.x > 0 || velocity.z > 0)
            animator.SetBool("isWalking", true);
        else
            animator.SetBool("isWalking", false);
    }
}

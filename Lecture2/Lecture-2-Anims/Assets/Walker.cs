using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3.0f;
    public Vector2 Velocity;
    bool isWalking;
    public Rigidbody2D rigidBody2D;
    public Animator animator;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Velocity = Vector2.zero;
        Velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        float NormalizedSpeed = Velocity.magnitude;

        if (NormalizedSpeed > .2f)
        {
            isWalking = true;
        }

        else
        {
            isWalking = false;
        }

        
        //isWalking = NormalizdSpeed > .2f; is shorter version

        Velocity.Normalize();
        animator.SetBool("isWalking", isWalking);

        if (NormalizedSpeed! > 0)
        {
            animator.SetFloat("Hori", Velocity.x);
            animator.SetFloat("Vert", Velocity.y);
        }
        
        

        Velocity *= speed;
        rigidBody2D.velocity   = Velocity;
    }
}
    
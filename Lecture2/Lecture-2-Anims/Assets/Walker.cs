using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3.0f;
    public Vector2 Velocity;
    bool IsWalking;
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

        if(NormalizedSpeed > .2f)
        {
            IsWalking = true;
        }
        else
        {
            IsWalking = false;
        }
        Velocity.Normalize();
        animator.SetFloat("Horizontal", Velocity.x);
        animator.SetFloat("Vertical", Velocity.y);
        animator.SetBool("IsWalking", IsWalking);

        Velocity *= speed;
        rigidBody2D.velocity   = Velocity;
    }
}
    
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {
    public float moveSpeed;
    public bool facingLeft;
    public bool moveLeft;
    public bool canMove;

    private Animator anim;
    
    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask WhatIsWall;
    private bool hitWall;


    public bool knockFromRight = true;
    private Rigidbody2D rb;
    public void flip()
    { //function check for flip the enemy when it changing side
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    //public int pointsOnDeath;
    // Use this for initialization
    public void getHit(float knockBackForce)
    {        
            if (knockFromRight)
            {
            rb.AddForce(Vector2.right * knockBackForce);
            }
            else
            {
            rb.AddForce(Vector2.left * knockBackForce);
            }
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void moving() {
        hitWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, WhatIsWall);
        if (hitWall)
        {//checking when enemy flip either hit the wall or at the edge
            moveLeft = !moveLeft;
        }
        if (moveLeft)
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y); //moving the enemy
        }
        else if(!moveLeft )
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y);
        }
        if (!moveLeft && facingLeft)
        {//if not moving to the left and facing to the left then flip
            flip();
        }
        if (moveLeft && !facingLeft)
        {//if moving to the left but not facing to the left then flip
            flip();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!canMove)
        {
            rb.velocity = new Vector3(0, rb.velocity.y);
        }
        else {
            moving();
        }
    }
    /*void OnTriggerEnter2D(Collider2D other)
    {//function for not continuingly hitting the player, still got some buggin but work fine
        if (other.tag == "Player")
        {
            moveLeft = !moveLeft;
        }
    }*/
}

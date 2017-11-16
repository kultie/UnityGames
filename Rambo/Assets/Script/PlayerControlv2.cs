using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlv2 : MonoBehaviour
{
    //What you need for moving the player
    //The speed
    public float battleStanceTime;
    private float moveSpeed;
    public float moveSpeedNormal;
    public float moveSpeedOnAir;
    private float moveVelocity;
    private bool facingLeft = false;
    private bool canMove;
    //What jump need
    public float jumpHeight;
    public float gravityScale;
    //Checking for jumping
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask WhatIsGround;
    public bool grounded;
    //Aimate, physics, and the current level system
    private Animator anim;
    private Rigidbody2D myrigidbody2D;
    //Camera Effects
    public CameraShake cameraShake;

    //public bool die = false;

    void flip()
    {//funciont for flip
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void jump()
    {//function for jumping
        if (grounded)
        { //Can only jump if on the ground and can jump
            Debug.Log("Jumping");
            myrigidbody2D.AddForce(Vector2.up * jumpHeight);
        }
    }
    public void onAir() {
        if (!grounded)
        {
            moveSpeed = moveSpeedOnAir;
        }
        else {
            moveSpeed = moveSpeedNormal;
        }
    }
    public void changeStance() {
        if (battleStanceTime > 0)
        {
            anim.SetBool("Battling", true);
        }
        else {
            anim.SetBool("Battling", false);
        }
    }
    public void moving(float moveInput)
    {//functino for moving
        if (canMove)
        {
            if (moveInput > -0.1f || moveInput < 0.1f)
            {
                float move = moveInput;//Gives us of one if we are moving via the arrow keys
                moveVelocity = moveSpeed;
                myrigidbody2D.velocity = new Vector3(move * moveVelocity, myrigidbody2D.velocity.y);
                //set our speed
                anim.SetFloat("Speed", Mathf.Abs(moveSpeed * moveVelocity));

                //if we are moving left but not facing left flip, and vice versa
                if (move < 0 && !facingLeft)
                {

                    flip();
                }
                else if (move > 0 && facingLeft)
                {
                    flip();
                }
            }
        }
    }
    private void Awake()
    {
        cameraShake = FindObjectOfType<CameraShake>().GetComponent<CameraShake>();
        anim = GetComponent<Animator>();
        myrigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {   //What you need when the game start? EVERYTHINGS
        canMove = true;
    }
    void FixedUpdate()
    {//by a fixed time pass
        //moving (Input.GetAxis("Horizontal"));//this will be disable in the apk file
    }
    void falling()
    {
        if (!grounded && myrigidbody2D.velocity.y < 0)
        {
            myrigidbody2D.gravityScale = gravityScale;
        }
        else if (grounded)
        {
            myrigidbody2D.gravityScale = 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        battleStanceTime -= Time.deltaTime;
        onAir();
        moving(Input.GetAxisRaw("Horizontal"));
        if (Input.GetKey(KeyCode.C))
        {
            jump();
        }
        if (Input.GetKey(KeyCode.Z))
        {
            StartCoroutine(attack1());
        }
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);//Are you on the ground?
        anim.SetBool("Grounded", grounded);//When on the ground
        anim.SetFloat("vSpeed", myrigidbody2D.velocity.y);
        moveVelocity = 0f;
        anim.SetFloat("Speed", Mathf.Abs(myrigidbody2D.velocity.x));//Get the speed for 
        falling();
        changeStance();
    }
    IEnumerator attack1(){
        anim.SetBool("Attacking", true);
        yield return new WaitForSeconds(0.12f);
        anim.SetBool("Attacking", false);
        battleStanceTime = 3f;
    }
}

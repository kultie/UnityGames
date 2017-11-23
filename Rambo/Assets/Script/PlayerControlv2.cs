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

    public float knockBackForce;
    public float knockbackCount;
    public float knockbackLength;
    public bool knockFromRight = true;


    //Attack
    public float attackRate = 0.12f;
    
    public string[] comboParams;
    public int comboIndex = 0;
    public float resetTimer;

    float cant_moveTime;
    float cant_attackTime;
    float cant_jumpTime;
    bool canAttack;

    void flip()
    {
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void jump()
    {
        if (grounded && cant_jumpTime <= 0)
        {
            Debug.Log("Jumping");
            myrigidbody2D.AddForce(Vector2.up * jumpHeight);
        }
    }
    public void onAir()
    {
        if (!grounded)
        {
            moveSpeed = moveSpeedOnAir;
            canAttack = false;
            
        }
        else
        {
            moveSpeed = moveSpeedNormal;
            canAttack = true;
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
        if (comboParams == null || (comboParams != null && comboParams.Length == 0))
            comboParams = new string[] { "Attack1", "Attack2", "Attack3" };
        cameraShake = FindObjectOfType<CameraShake>().GetComponent<CameraShake>();
        anim = GetComponent<Animator>();
        myrigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        canMove = true;
    }
    void FixedUpdate()
    {
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
    void timeControl() {
        cant_attackTime -= Time.deltaTime;
        cant_jumpTime -= Time.deltaTime;
        resetTimer += Time.deltaTime;
        cant_moveTime -= Time.deltaTime;
        knockbackCount -= Time.deltaTime;
    }
    void Update()
    {
        timeControl();
        if (cant_moveTime >= 0)
        {
            canMove = false;
            myrigidbody2D.velocity = new Vector3(0, myrigidbody2D.velocity.y);
        }
        else {
            canMove = true;
        }
        battleStanceTime -= Time.deltaTime;
        if (battleStanceTime > 0) {
            anim.SetBool("Battling", true);
        }
        else
        {
            anim.SetBool("Battling", false);
        }
        onAir();
        moving(Input.GetAxisRaw("Horizontal"));
        if (Input.GetKey(KeyCode.C))
        {
            cant_attackTime = 0.3f;
            jump();
        }
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);//Are you on the ground?
        anim.SetBool("Grounded", grounded);//When on the ground
        anim.SetFloat("vSpeed", myrigidbody2D.velocity.y);
        moveVelocity = 0f;
        anim.SetFloat("Speed", Mathf.Abs(myrigidbody2D.velocity.x));//Get the speed for 
        falling();
        getHit();
        attack();
    }
    void attack() {
        if (Input.GetKeyDown(KeyCode.Z) && comboIndex < comboParams.Length && cant_attackTime <= 0 && canAttack)
        {
            cant_jumpTime = 0.8f;
            battleStanceTime = 5f;
            attackRate = 0.35f;
            if (comboIndex == 2)
            {
                cant_attackTime = 0.8f;
                cant_moveTime = 0.8f;
                
                canAttack = false;
            }
            else
            {
                cant_moveTime = 0.5f;
            }
            Debug.Log(comboParams[comboIndex] + " triggered");
            anim.SetTrigger(comboParams[comboIndex]);
            comboIndex++;
            resetTimer = 0f;
        }
        if (comboIndex > 0)
        {
            if (resetTimer > attackRate)
            {
                anim.SetTrigger("Reset");
                comboIndex = 0;
            }
        }
    }
    public void getHit()
    {
        //cant_attackTime = knockbackCount + 0.3f;
        if (knockbackCount > 0)
        {
            canAttack = false;
            anim.SetBool("Hit", true);//Animate
            if (knockFromRight)
            {//When you get hit from the right
                myrigidbody2D.velocity = new Vector2(-knockBackForce, 2f);
                if (facingLeft)
                {
                    flip();
                }
            }
            else
            {//And from the left
                myrigidbody2D.velocity = new Vector2(knockBackForce, 2f);
                if (!facingLeft)
                {
                    flip();
                }
            }
        }
        else
        {//The knock back time is over now you can do things
            canMove = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed;
    private float moveVelocity;
    private bool facingLeft = false;
    private Rigidbody2D myrigidbody2D;
    private Animator anim;
    public float meleeTimer;
    private float meleeTimeCounter;
    public float shootingTimer;
    private float shootingTimeCounter;
    private float attackTimerCounter;
    public bool canMove;
    public float staggerTimeCounter;
    //public PlayerInteraction playerInter;
    void Flip()
    {//funciont for flip
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void stagger()
    {
        if (staggerTimeCounter>0) {
            canMove = false;
            anim.SetBool("Hit", true);
            staggerTimeCounter -= Time.deltaTime;
        }
        else
        {
            anim.SetBool("Hit", false);
        }
    }
    public void melee()
    {
        if (meleeTimeCounter > 0)
        {
            anim.SetBool("Attack", true);
            meleeTimeCounter -= Time.deltaTime;
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }
    public void shoot() {
        if (shootingTimeCounter > 0)
        {
            anim.SetBool("Shoot", true);
            shootingTimeCounter -= Time.deltaTime;
        }
        else
        {
            anim.SetBool("Shoot", false);
        }
    }
    public void attack() {
        if (attackTimerCounter > 0)
        {
            canMove = false;
            attackTimerCounter -= Time.deltaTime;
        }
        else
        {
            canMove = true;
        }
    }
    public void movingHorizontal(float moveInput)
    {//functino for moving
        if ((moveInput > -0.1f || moveInput < 0.1f))
        {
            float move = moveInput;//Gives us of one if we are moving via the arrow keys
            if (canMove)
            {
                moveVelocity = moveSpeed;
                myrigidbody2D.velocity = new Vector3(move * moveVelocity, myrigidbody2D.velocity.y);
                anim.SetFloat("Speed", Mathf.Abs(move * moveVelocity));
            }
            else
            {
                myrigidbody2D.velocity = new Vector3(0, myrigidbody2D.velocity.y);
            }
            if (move < 0 && !facingLeft)
            {
                Flip();
            }
            else if (move > 0 && facingLeft)
            {
                Flip();
            }
        }
    }
    public void movingVertical(float moveInput)
    {
        if (moveInput > -0.1f || moveInput < 0.1f)
        {
            float move = moveInput;//Gives us of one if we are moving via the arrow keys
            if (canMove)
            {
                moveVelocity = moveSpeed / 2;
                myrigidbody2D.velocity = new Vector3(myrigidbody2D.velocity.x, move * moveVelocity);
                anim.SetFloat("vSpeed", Mathf.Abs(move * moveVelocity));
            }
            else
            {
                myrigidbody2D.velocity = new Vector3(myrigidbody2D.velocity.x, 0);
            }
        }
    }
        // Use this for initialization
        void Start () {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        movingHorizontal(Input.GetAxisRaw("Horizontal"));
        movingVertical(Input.GetAxisRaw("Vertical"));
        if (Input.GetKey(KeyCode.Z))
        {
            meleeTimeCounter = meleeTimer;
            attackTimerCounter = meleeTimer;
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            shootingTimeCounter = shootingTimer;
            attackTimerCounter = shootingTimer;
        }
        attack();
        shoot();
        melee();
        stagger();
    }
}

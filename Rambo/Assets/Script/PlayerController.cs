using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{//What you need for moving the player
    //The speed
    public float moveSpeed;
    private float moveVelocity;
    private bool facingLeft = false;
    private bool canMove;
    //Checking bulltet
    public GameObject bulletPref;
    public Transform gunPoint;
    public float randomDist = 0.1f;
    public float fireRate = 0.05f;
    private float nextFire = 0;
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
    void shoot() {
        float randomYOffset = Random.Range(-randomDist, randomDist);
        Vector3 bulletPosition = new Vector3(gunPoint.position.x, gunPoint.position.y + randomYOffset, gunPoint.position.z);
        Instantiate(bulletPref, bulletPosition, gunPoint.rotation * Quaternion.Euler(Random.Range(-10, 10), 0, 0));
        //Add camera shake
        cameraShake.StartShake();
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
    void falling() {
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
        moving(Input.GetAxisRaw("Horizontal"));
        if (Input.GetKey(KeyCode.C)) {
            jump();
        }
        if (Input.GetKey(KeyCode.Z) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            shoot();
        }
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);//Are you on the ground?
        anim.SetBool("Ground", grounded);//When on the ground
        anim.SetFloat("vSpeed", myrigidbody2D.velocity.y);
        moveVelocity = 0f;
        anim.SetFloat("Speed", Mathf.Abs(myrigidbody2D.velocity.x));//Get the speed for 
        falling();
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour {
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask WhatIsGround;
    public bool grounded;
    public float speed;
    public float slowSpeed;
    public GameObject groundHitBox;
    private Animator anim;
    private Rigidbody2D myrigidbody2D;
    EnemyPatrol ePatrol;
    EnemyManager eManager;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        ePatrol = GetComponent<EnemyPatrol>();
        eManager = GetComponent<EnemyManager>();
        myrigidbody2D = GetComponent<Rigidbody2D>();
    }
    void detectPlayer() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right * -1*(System.Convert.ToInt32(ePatrol.facingLeft)),5f);
        Debug.DrawRay(transform.position, Vector3.right * -5 * (System.Convert.ToInt32(ePatrol.facingLeft)), Color.red, 2f, false);
        if (hit.collider.CompareTag("Player"))
        {
            StartCoroutine(shoot());
        }
    }
    private void FixedUpdate()
    {
        detectPlayer();
    }
    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
        if (!grounded)
        {
            ePatrol.moveSpeed = slowSpeed;
            groundHitBox.GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            ePatrol.moveSpeed = speed;
            groundHitBox.GetComponent<Collider2D>().enabled = true;
        }
        if (eManager.enemyHP <= 0)
        {
            ePatrol.canMove = false;
            StartCoroutine(death());
        }
    }
    IEnumerator death()
    {
        anim.SetBool("Dead", true);
        yield return new WaitForSeconds(0.76f);
        Destroy(this.gameObject);
    }
    IEnumerator shoot()
    {
        anim.SetBool("Shooting", true);
        yield return new WaitForSeconds(0.76f);
        Debug.Log("Shooting");
        anim.SetBool("Shooting", false);
    }
}

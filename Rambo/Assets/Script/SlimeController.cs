using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour {
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask WhatIsGround;
    public bool grounded;

    public GameObject groundHitBox;
    private Animator anim;
    private Rigidbody2D myrigidbody2D;
    EnemyPatrol ePatrol;
    EnemyManager eManager;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        ePatrol = GetComponent<EnemyPatrol>();
        eManager = GetComponent<EnemyManager>();
	}
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
        anim.SetBool("Ground", grounded);
        if (!grounded)
        {
            ePatrol.canMove = false;
            groundHitBox.GetComponent<Collider2D>().enabled = false;
        }
        else {
            ePatrol.canMove = true;
            groundHitBox.GetComponent<Collider2D>().enabled = true;
        }
        if (eManager.enemyHP <= 0)
        {
            ePatrol.canMove = false;
            StartCoroutine(death());
        }
    }
    IEnumerator death() {
        anim.SetBool("Dead", true);
        yield return new WaitForSeconds(0.76f);
        Destroy(this.gameObject);
    }
}

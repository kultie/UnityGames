using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour {
    Rigidbody2D rb;
    Animator anim;
    private bool facingLeft = false;
    public bool canMove = true;
    int facingLeft_int;
    // Use this for initialization
    void Flip()
    {//funciont for flip
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    int convertBooltoInt()
    {
        if (facingLeft == false)
        {
            facingLeft_int = -1;
        }

        else
        {
            facingLeft_int = 1;
        }
        return facingLeft_int;
    }
    void knockBack()
    {

    }
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("vSpeed", Mathf.Abs(rb.velocity.y));
        if (rb.velocity.x * convertBooltoInt() > 0 && canMove)
        {
            Flip();
        }
        if (!canMove)
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
            
}

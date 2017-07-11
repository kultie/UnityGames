using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareController : MonoBehaviour {
    public float moveSpeed = 8f;
    private float moveVelocity;
    private Rigidbody2D myrigidbody2D;
    private bool canMoveHorizontal;
    private bool canMoveVertical;
    // Use this for initialization
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void movingHorizontal()
    {   moveVelocity = moveSpeed;
        if (canMoveHorizontal)
        {
            myrigidbody2D.velocity = new Vector3(moveVelocity * Input.GetAxisRaw("Horizontal"), 0);
        }
    }
    public void movingVertical()
    {
        moveVelocity = moveSpeed;
        if (canMoveVertical)
        {
            myrigidbody2D.velocity = new Vector3(0, moveVelocity * Input.GetAxisRaw("Vertical"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            canMoveVertical = false;
        }
        else {
            canMoveVertical = true;
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            canMoveHorizontal = false;
        }
        else
        {
            canMoveHorizontal = true;
        }
        movingHorizontal();
        movingVertical();
    }
}


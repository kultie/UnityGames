using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour {
    public float moveSpeed = 8f;
    private float moveVelocity;
    private Rigidbody2D myrigidbody2D;
    public float rotationOffSet;

    public GameObject respawnPoint;

    public Transform BulletPref;
    public LayerMask notToHit;
    float timeToFire = 0;
    public Transform firePoint;
    public Vector2 mousePos;
    float rotZ;
    // Use this for initialization
    void Start () {
        myrigidbody2D = GetComponent<Rigidbody2D>();
	}
    public void movingHorizontal(float moveInput)
    {//functino for moving
        if ((moveInput > -0.1f || moveInput < 0.1f))
        {
            float move = moveInput;//Gives us of one if we are moving via the arrow keys
            moveVelocity = moveSpeed;
            myrigidbody2D.velocity = new Vector3(move * moveVelocity, myrigidbody2D.velocity.y);
        }
    }
    public void movingVertical(float moveInput)
    {
        if (moveInput > -0.1f || moveInput < 0.1f)
        {
            float move = moveInput;//Gives us of one if we are moving via the arrow keys
            moveVelocity = moveSpeed;
            myrigidbody2D.velocity = new Vector3(myrigidbody2D.velocity.x, move * moveVelocity);
        }
    }
    public void circleRot() {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
    public void shoot()
    {
        mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPos = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPos, mousePos - firePointPos, 100, notToHit);
        Effect();      
    }
    void Effect() {
        Instantiate(BulletPref, firePoint.position, Quaternion.Euler(0f, 0f, rotZ - 90));
    }
    // Update is called once per frame
    void Update () {
        movingHorizontal(Input.GetAxisRaw("Horizontal"));
        movingVertical(Input.GetAxisRaw("Vertical"));
        circleRot();
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }
}

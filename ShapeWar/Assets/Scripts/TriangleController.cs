using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleController : MonoBehaviour {
    public float moveSpeed = 8f;
    public float rotationOffSet = 0;
    public float mouseOffSetToMoving = 0.5f;
    private bool canMove;
    private Vector3 target;

    public Transform BulletPref;
    public LayerMask notToHit;
    float timeToFire = 0;
    public Transform firePoint;
    float rotZ;
    // Use this for initialization
    void Start () {
		
	}
    public void shoot()
    {
        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPos = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPos, mousePos - firePointPos, 100, notToHit);
        Effect();

    }
    void Effect()
    {
        Instantiate(BulletPref, firePoint.position, Quaternion.Euler(0f, 0f, rotZ + rotationOffSet));
    }
    void triRot() {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (Mathf.Abs(difference.x) < mouseOffSetToMoving && Mathf.Abs(difference.y) < mouseOffSetToMoving)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }

        difference.Normalize();

        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffSet);
    }
    void triMov() {
        if (Input.GetAxisRaw("Vertical") > 0.1f)
        {
            target = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            if (canMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            }
        }
    }
    // Update is called once per frame
    void Update () {
        triMov();
        triRot();
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }
}

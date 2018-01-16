using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float rotationOffSet = 0;
    public float mouseOffSetToMoving = 0.5f;
    private Vector3 target;

    public Transform BulletPref;
    public LayerMask notToHit;
    public float timeInterval = 0.05f;
    float currentShootTime;
    float timeToFire = 0;
    public Transform firePoint;
    float rotZ;

    public float timeUntilRespawn;
    SpriteRenderer sp;

    private Rigidbody2D rb;

    public bool IsDead { get { return timeUntilRespawn > 0; } }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }
    public void shoot()
    {
        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPos = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPos, mousePos - firePointPos, 100, notToHit);
        if (currentShootTime <= 0f)
        {
            Effect();
            currentShootTime = timeInterval;
        }
        currentShootTime -= Time.deltaTime;

    }
    void Effect()
    {
        Instantiate(BulletPref, firePoint.position, Quaternion.Euler(0f, 0f, rotZ + rotationOffSet));

    }
    void triRot()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffSet);
    }
    /*void triMov()
    {
        float currentAccelRate = shipAccelRate;
        if (Input.GetAxisRaw("Vertical") > 0.1f)
            target = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        {
            if (canMove)
            {
                rb.AddForce(transform.up * currentAccelRate);
                if (rb.velocity.magnitude > shipMaxSpeed)
                {
                    currentAccelRate = 0;
                }
                else
                {
                    currentAccelRate = shipAccelRate;
                }
            }
        }
    }*/
    void triMov()
    {
        
        if (Input.GetAxisRaw("Vertical") > 0.1f)
        {
            target = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
                //rb.AddForce(target - transform.position);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (IsDead)
        {
            sp.enabled = false;
            timeUntilRespawn-=Time.deltaTime;
            return;
        }
        else {
            sp.enabled = true;
        }
        triMov();
        triRot();
        shoot();
    }
    public void dead() {
       
        timeUntilRespawn = 2f;
    }
}

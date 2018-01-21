using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    public ObjectPooler bulletPool;
    public float rotationOffSet = 0;
    public float mouseOffSetToMoving = 0.5f;
    private Vector3 target;

    public Transform BulletPref;
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
        if (currentShootTime <= 0f)
        {
            Effect();
            currentShootTime = timeInterval;
        }
        currentShootTime -= Time.deltaTime;

    }
    void Effect()
    {
        GameObject obj = bulletPool.getPooledObject();
        if (obj == null) return;
        obj.transform.position = firePoint.position;
        obj.transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffSet);
        obj.SetActive(true);
        //Instantiate(BulletPref, firePoint.position, Quaternion.Euler(0f, 0f, rotZ + rotationOffSet));

    }
    void triRot()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffSet);
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
        triRot();
        shoot();
    }
    public void dead() {
       
        timeUntilRespawn = 2f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public float rotationOffSet = 90;
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
    // Update is called once per frame
    void Update () {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffSet);
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }
}

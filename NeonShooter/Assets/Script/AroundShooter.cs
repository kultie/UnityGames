using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundShooter : MonoBehaviour {

    public float rotateSpeed;
    public Transform shooter;
    public GameObject bulletPref;
    public float shootingTimer = 0.01f;
    private float shootingTimeCounter;
    public float shootingOffSet;
    public float bossThreshHoldRatio;
    private void Start()
    {
        shootingTimeCounter = shootingTimer;
        shootingOffSet = 0;
    }
    private void Update()
    {
        shooter.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
        if (shootingTimeCounter > 0)
        {
            shootingTimeCounter -= Time.deltaTime;
        }
        else
        {
            Instantiate(bulletPref, transform.position, this.transform.rotation);
            shootingTimeCounter = shootingTimer;
        }
    }
}

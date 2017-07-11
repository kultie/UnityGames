using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAround : MonoBehaviour {

    public GameObject bulletPref;
    public EnemyManager bossBody;
    public int bulletNumber;
    private bool canShoot;
    public float shootingTimer;
    private float shootingTimeCounter;
    public float shootingOffSet;
    public float bossThreshHoldRatio;
    private void Start()
    {
        bossBody = GameObject.FindGameObjectWithTag("Boss").GetComponent<EnemyManager>();
        canShoot = false;
        shootingTimeCounter = shootingTimer;
        shootingOffSet = 0;
        bulletNumber = Random.Range(3, 6);
    }
    private void Update()
    {
        if (bossBody.getCurrentHP() <= bossBody.enemyHP* bossThreshHoldRatio) {
            canShoot = true;
        }
        if (canShoot)
        {
            if (shootingTimeCounter > 0)
            {
                shootingTimeCounter -= Time.deltaTime;
            }
            else
            {
                for (int i = 0; i < bulletNumber; i++)
                {
                    Instantiate(bulletPref, transform.position, Quaternion.Euler(0f, 0f, shootingOffSet));
                    shootingOffSet += 360 / bulletNumber;
                }
                shootingOffSet = Random.Range(45.0f, 90.0f);
                shootingTimeCounter = Random.Range(3, 6);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitShooter : MonoBehaviour {

    public GameObject target;
    public float orbitDistance;
    public float orbitDegreesPerSec = 180.0f;
    private float orbitTimeCounter;
    public float orbitTime;
    public float orbitCoffiency;

    private float shootingTimeCounter;
    public float shootingTimer;

    public GameObject bulletPrefs;
    // Use this for initialization
    void Start()
    {
        orbitDistance = Random.Range(3f, 5f);
        shootingTimeCounter = Random.Range(0f, shootingTimer);
        target = GameObject.FindGameObjectWithTag("Boss");
        Destroy(this.gameObject, orbitTime * 2);
    }

    void Orbit(float orbitCoffien)
    {
        if (target != null)
        {
            transform.position = target.transform.position + (transform.position - target.transform.position).normalized * orbitDistance;
            transform.RotateAround(target.transform.position, Vector3.forward, orbitCoffien * orbitDegreesPerSec * Time.deltaTime);
        }
    }
    void shooting()
    {
        if (shootingTimeCounter > 0)
        {
            shootingTimeCounter -= Time.deltaTime;
        }
        else
        {
            Instantiate(bulletPrefs, transform.position, transform.rotation);
            shootingTimeCounter = Random.Range(shootingTimer/2,shootingTimer);
        }
    }
    void Update()
    {
        shooting();
        if (orbitTimeCounter > 0)
        {
            Orbit(orbitCoffiency);
            orbitTimeCounter -= Time.deltaTime;
        }
        else
        {
            orbitTimeCounter = orbitTime;
            orbitCoffiency *= -1;
        }
    }
}

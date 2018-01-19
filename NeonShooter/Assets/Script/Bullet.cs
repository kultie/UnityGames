using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    Grid grid;

    public float bulletSpeed;
    public float encroachSpeed;
    private void Start()
    {
        grid = FindObjectOfType<Grid>().GetComponent<Grid>();

    }
    private void OnEnable()
    {
        transform.localScale = Vector3.one;
    }
    public int damage;
    public void bulletAction(float speed) {

        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    private void Update()
    {
        grid.ApplyExplosiveForce(0.5f*bulletSpeed, transform.position, 2.5f);
        bulletAction(bulletSpeed);
    }
}

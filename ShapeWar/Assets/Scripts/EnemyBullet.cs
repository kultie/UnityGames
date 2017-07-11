using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    private Respawn respawn;
    public int speed = 20;
    public float timeLive = 1;
    private void Start()
    {
        respawn = FindObjectOfType<Respawn>();
        Destroy(this.gameObject, timeLive);
    }
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            respawn.respawn();
        }
    }
}

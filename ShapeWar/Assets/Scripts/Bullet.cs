using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public int damage;
    public int speed = 20;
    public float timeLive = 1;
    // Update is called once per frame
    private void Start()
    {
        Destroy(this.gameObject, timeLive);
    }
	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Boss")
        {
            collision.GetComponent<EnemyManager>().giveDamage(damage);
            Destroy(this.gameObject);
        }
    }
}

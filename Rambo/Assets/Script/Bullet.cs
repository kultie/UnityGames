using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 200f;
    public GameObject hitEffect;
    private PlayerController player;
    public float bulletLifeTime = 0.5f;
    public float timeDestroy = 0.55f;
    Animator anim;
    //public GameObject hitEffect;
    private Rigidbody2D rb2D;
    // Use this for initialization
    void Start()
    {//find playercontroller objects
        Destroy(this.gameObject, timeDestroy);
        rb2D = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();
        if (player.transform.localScale.x < 0)
        {//flip side when player flip
            speed *= -1;
            transform.localScale *= -1;
        }

    }

    // Update is called once per frame
    void Update()
    {//flying when shoot
        bulletLifeTime -= Time.deltaTime;
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        if (bulletLifeTime <= 0) {
            anim.SetBool("TimeUp", true);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    //public LevelManager levelManager;
    public PlayerControlv2 player;
    public float attackForce;
    public int damage;
    // Use this for initialization
    void Start()
    {//find necessary components and objects
        //levelManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<PlayerControlv2>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {//if collide with player
            if (transform.position.x < other.transform.position.x)
            {
                player.knockFromRight = false;
            }
            else
            {
                player.knockFromRight = true;
            }
            other.GetComponent<HealthManager>().hurt(damage);
        }
    }
}

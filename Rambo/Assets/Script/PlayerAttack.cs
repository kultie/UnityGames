using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    public int damage;
    PlayerControlv2 player;
    public float attackForce;
    EnemyPatrol ePatrol;
    void Start()
    {
        player = FindObjectOfType<PlayerControlv2>().GetComponent<PlayerControlv2>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {//When player attack and hit enemy, deal damage to them
        if (other.tag == "Enemy")
        {
            ePatrol = other.GetComponent<EnemyPatrol>();
            other.GetComponent<EnemyManager>().giveDamage(damage);//Get enemy components to give them what they deserve
            if (player.transform.position.x > other.transform.position.x)
            {
                ePatrol.knockFromRight = false;
            }
            else
            {
                ePatrol.knockFromRight = true;
            }
            ePatrol.getHit(attackForce);
        }
    }
}

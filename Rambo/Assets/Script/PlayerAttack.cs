using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    public int damage = 10;
    void Start()
    {
    }
    void OnTriggerEnter2D(Collider2D other)
    {//When player attack and hit enemy, deal damage to them
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyManager>().giveDamage(damage);//Get enemy components to give them what they deserve
        }
    }
}

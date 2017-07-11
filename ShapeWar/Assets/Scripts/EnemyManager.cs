using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public float enemyHP;
    private float enemyCurrentHP;
    // Use this for initialization
    void Start()
    {
        enemyCurrentHP = enemyHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCurrentHP <= 0)
        {//if enemy's HP < 0 destroy it
            Destroy(gameObject);
        }
    }
    public float getCurrentHP() {
        return enemyCurrentHP;
    }
    public void giveDamage(float damageDealt)
    {//deal damage function
        enemyCurrentHP -= damageDealt;
    }
}

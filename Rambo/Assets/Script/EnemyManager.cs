using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public int enemyHP;
    public void giveDamage(int damageDealt)
    {//deal damage function
        enemyHP -= damageDealt;
    }
}

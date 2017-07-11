using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHPThreshold : MonoBehaviour {
    private EnemyManager boss;
    private ArmGenerate weaponGen;
    public float hpRatio;
    private float bossHP;
	// Use this for initialization
	void Start () {
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<EnemyManager>();
        weaponGen = GetComponent<ArmGenerate>(); 
	}
	
	// Update is called once per frame
	void Update () {
        bossHP = boss.getCurrentHP();
        if (bossHP < boss.enemyHP * hpRatio)
        {
            weaponGen.enabled = true;
        }
        else {
            weaponGen.enabled = false;
        }
    }
}

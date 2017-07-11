using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmGenerate : MonoBehaviour {
    public GameObject armForThisPos;
    private GameObject bossBody;
    private bool bossInDanger;
    public float timeGen;
    public float timeGenInitiate;
    private float timeGenCounter;
    public float bossHPRatio;
    private float bossCurrentHP;
	// Use this for initialization
	void Start () {
        timeGen = timeGenInitiate;
        timeGenCounter = timeGenInitiate;

    }

    // Update is called once per frame
    void Update()
    {
        if (timeGenCounter > 0) {
            timeGenCounter -= Time.deltaTime;
        }
        else {
            Instantiate(armForThisPos, transform.position, transform.rotation);
            timeGenCounter = timeGen;
        }
        bossCurrentHP = GameObject.FindGameObjectWithTag("Boss").GetComponent<EnemyManager>().getCurrentHP();
        if (bossCurrentHP <= GameObject.FindGameObjectWithTag("Boss").GetComponent<EnemyManager>().enemyHP * bossHPRatio) {
            timeGen = timeGenInitiate / 2;
        }
    }
}

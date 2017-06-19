using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    Animator anim;
    EnemyAI enemy;
    EnemyAction enemAction;
    float speed_tmp;
    public float attackTimer  = 0.6f;
    float curAttackTimer;
	// Use this for initialization
	void Start () {
        anim = transform.parent.GetComponent<Animator>();
        enemy = transform.parent.GetComponent<EnemyAI>();
        enemAction = transform.parent.GetComponent<EnemyAction>();
        speed_tmp = enemy.speed;
    }
	
	// Update is called once per frame
	void Update () {
        if (curAttackTimer > 0)
        {
            anim.SetBool("Attack", true);
            enemAction.canMove = false;
            curAttackTimer -= Time.deltaTime;
        }
        else
        {
            enemAction.canMove = true;
            anim.SetBool("Attack", false);
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("Touched!");
            //StartCoroutine(Attack());
            curAttackTimer = attackTimer;
        }
    }
}

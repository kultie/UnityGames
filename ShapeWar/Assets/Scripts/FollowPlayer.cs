using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public float rotationOffSet = 0;
    public float moveSpeed;
    public bool attacking;
    public float attackTimer;
    public float attackTimeCounter;
    public float timeToAim;
    public float timeToAimCounter;
    public Transform target;
    //private Transform currentTarget;
    private void Start()
    {

        attackTimeCounter = 0;
        moveSpeed = Random.Range(4.0f, 7.0f);
        attackTimer = Random.Range(3.0f, 6.0f);
    }
    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        attackTimeCounter -= Time.deltaTime;
        aimingAtPlayer();
        if (target != null)
        {
            StartCoroutine(attackPlayer(target));
        }
        else {
            target = GameObject.FindGameObjectWithTag("Boss").transform;
        }
    }
    private void aimingAtPlayer()
    {
        if (timeToAimCounter > 0)
        {
            timeToAimCounter -= Time.deltaTime;
        }
        else
        {
            timeToAimCounter = timeToAim;
        }
    }
    private IEnumerator attackPlayer(Transform target)
    {
        if (attackTimeCounter <= 0 && target!= null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            yield return new WaitForSeconds(attackTimer);
            attackTimer = Random.Range(3.0f, 8.0f);
            attackTimeCounter = attackTimer / 2;
        }
    }
}

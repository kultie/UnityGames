using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject[] enemies;

    public float resetPosTimer;
    float resetPosTimeCounter;

    public int enemyCounter;
    public int enemyNumber;
    // Use this for initialization
    void Start() {
        enemyCounter = 0;
        resetPosTimeCounter = resetPosTimer;
    }
    public void enemyDead() {
        enemyCounter--;
    }
	// Update is called once per frame
	void Update () {
        Vector2 pos = new Vector2(Random.Range(-12.0f, 12.0f),(Random.Range(-5.0f, 5.0f )));
        if (resetPosTimeCounter <= 0) {
            transform.position = pos;
            resetPosTimeCounter = resetPosTimer;
            if (enemyCounter < enemyNumber)
            {
                int enemyRandom = Random.Range(1, 100);
                if (enemyRandom > 10)
                {
                    Instantiate(enemies[0], transform.position, Quaternion.identity);
                }
                else {
                    Instantiate(enemies[1], transform.position, Quaternion.identity);
                }
                enemyCounter++;
            }
        }
        else{
            resetPosTimeCounter -= Time.deltaTime;
        }
	}
}

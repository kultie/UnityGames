using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour {
    private Respawn respawn;
    public GameObject boss;
    public float moveSpeed = 20f;
    public float boomerangTimer;
    public float boomerangLiveTime;
    public bool returning;
    // Use this for initialization
    private void Start()
    {
        respawn = FindObjectOfType<Respawn>();
        Destroy(this.gameObject, 2*boomerangLiveTime);
        boss = GameObject.FindGameObjectWithTag("Boss");
        boomerangTimer = 0;
    }
    // Update is called once per frame
	// Update is called once per frame
	void Update () {
        boomerangTimer += Time.deltaTime;
        if (boomerangTimer >= boomerangLiveTime) {
            returning = true;
        }
        else { returning = false; }
        if (!returning)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else {
            var dir = boss.transform.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            respawn.respawn();
        }
        if (collision.tag == "Boss") {
            Destroy(this.gameObject);
        }
    }
}

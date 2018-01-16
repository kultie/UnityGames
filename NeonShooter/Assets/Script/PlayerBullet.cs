using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet {
    public float bulletSpeed;
    public float encroachSpeed;

    SpriteRenderer sp;
    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update () {
        base.bulletAction(bulletSpeed);
        base.destroy(sp);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBullet :Bullet {

    public float starBulletSpeed;
    public float starBulletTimeLive;

    public float minimum;
    public float maximum;
    public float duration;
    public float timeUntilAction;
    private float startTime;
    public SpriteRenderer sprite;
    private void Start() {
        Destroy(this.gameObject, starBulletTimeLive);
    }
    void fade()
    {
        float t = (Time.time - startTime) / duration;
        sprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, t));
    }
    private void Update() {
        fade();
    }
}

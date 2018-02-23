using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private float startTime;
    public float duration;
    public float minimum;
    public float maximum;

    public SpriteRenderer sprite;

    Vector3 startColor;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        startTime = Time.time;
        startColor = new Vector3(sprite.color.r, sprite.color.g, sprite.color.b);
    }
    void fade()
    {
        float t = (Time.time - startTime) / duration;
        sprite.color = new Color(startColor.x, startColor.y, startColor.z, Mathf.SmoothStep(minimum, maximum, t));
    }
    private void Update()
    {
        fade();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAction : MonoBehaviour {
    public GameObject arroundShooter;
    GameObject player;

    public float speed;
    public float minimum;
    public float maximum;
    public float duration;
    public float timeUntilAction;
    private float startTime;
    public SpriteRenderer sprite;

    public float moveTimeCounter;
    public float moveTimer;

    public Vector2 dir;
    int moveTrick;

    public float rotSpeed = 100f;


    Rigidbody2D rb;
    void Start()
    {
        player = FindObjectOfType<SpaceShipController>().gameObject;
        rb = GetComponent<Rigidbody2D>();
        startTime = Time.time;
        moveTimeCounter = 0;
    }
    void Update()
    {
        transform.Rotate(0f, 0f, rotSpeed * Time.deltaTime);
        fade();
        if (timeUntilAction <= 0)
        {
            if (moveTimeCounter > 0)
            {
                move(moveTrick);
                moveTimeCounter -= Time.deltaTime;
            }
            else {
                moveTrick = Random.Range(0, 100);
                dir = Random.insideUnitCircle;
                moveTimeCounter = moveTimer;
            }
            if (!sprite.isVisible)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            timeUntilAction-=Time.deltaTime;
        }
    }
    void fade() {
        float t = (Time.time - startTime) / duration;
        sprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, t));
    }
    public void move(int moveTrick)
    {
        if (moveTrick <= 33)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else {
            transform.Translate(dir * speed * Time.deltaTime, Space.World);
        }
    }
    public void OnDestroy()
    {
        EnemySpawner eSpawner = FindObjectOfType<EnemySpawner>().GetComponent<EnemySpawner>();
        eSpawner.enemyDead();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAction : MonoBehaviour {
    GameObject player;
    CharacterManager cm;

    public float speed;
    public float timeUntilAction;
    public SpriteRenderer sprite;

    Vector3 startColor;

    public float moveTimeCounter;
    public float moveTimer;

    public Vector2 dir;
    int moveTrick;

    public float rotSpeed = 100f;


    Rigidbody2D rb;
    void Awake()
    {
        cm = GetComponent<CharacterManager>();
        sprite = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<SpaceShipController>().gameObject;
        rb = GetComponent<Rigidbody2D>();
        moveTimeCounter = 0;
    }
    void Update()
    {
        transform.Rotate(0f, 0f, rotSpeed * Time.deltaTime);
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
}

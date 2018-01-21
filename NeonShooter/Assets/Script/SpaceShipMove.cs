using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMove : MonoBehaviour {
    public SpriteRenderer sp;
    public Vector2 moveSpeed;
    private void Start()
    {
        sp = GetComponentInChildren<SpriteRenderer>();
    }
    void triMov()
    {
        horizontal();
        vertical();
    }
    void horizontal()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(moveSpeed.x * Time.deltaTime * Input.GetAxisRaw("Horizontal"),0f,0f);
        }
    }
    void vertical()
    {
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(0f,moveSpeed.y * Time.deltaTime * Input.GetAxisRaw("Vertical"),0f);
        }
    }
    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -6.3f, 6.3f);
        pos.y = Mathf.Clamp(pos.y, -4.6f, 4.6f);
        transform.position = pos;
        triMov();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {
    public float maxSpeed;
    public float minSpeed;
    float speed;
    public float currentSpeed;
    public float duration = 1f;
    private float startTime;

    bool bounced = false;
    public int dir;
    public SpriteRenderer sp;
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    private void OnEnable()
    {
        bounced = false;
        dir = 1;
        startTime = Time.time;
        speed = Random.Range(minSpeed,maxSpeed);
        currentSpeed = speed;
        Invoke("destroy", duration);
}
    private void OnDisable()
    {
        setColor(new Vector3(1f, 1f, 1f),1f);
        CancelInvoke();
    }
    private void destroy()
    {
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update() {
        fade();
        move();
    }
    void fade() {
        float t = (Time.time - startTime) / duration;
        sp.color = new Color(sp.color.r,sp.color.g,sp.color.b, Mathf.SmoothStep(1, 0, t));
        transform.localScale = new Vector2(transform.localScale.x, Mathf.SmoothStep(1.94f, 0, t));
    }
    private void move()
    {
        currentSpeed = Mathf.SmoothStep(speed, 0, (Time.time - startTime) / duration);
        /*if (currentSpeed > 0)
        {
            currentSpeed -= Time.deltaTime * 10f;
        }
        else
        {
            currentSpeed += Time.deltaTime * 2f;
        }*/
        if (!sp.IsVisibleFrom(Camera.main) && bounced == false)
        {
            bounced = true;
            dir = -1;
        }
        transform.Translate(Vector3.up * Time.deltaTime * currentSpeed * dir);
    }
    public void orbit(Transform target, Vector3 dir, float orbitDistance, float speed, float orbitCoffiency)
    {
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 5 * Time.deltaTime);
        transform.position = target.transform.position + (transform.position - target.transform.position).normalized * orbitDistance;
        transform.RotateAround(target.transform.position, Vector3.forward, orbitCoffiency * speed * Time.deltaTime);
    }
    public void setColor(Vector3 color, float a) {
        sp.color = new Color(color.x, color.y, color.z,a);
    }
}

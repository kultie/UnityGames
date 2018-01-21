using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {
    BlackHole[] blackholes;
    public float maxSpeed;
    public float minSpeed;
    float speed;
    float currentSpeed;
    float duration = 1f;
    private float startTime;
    public SpriteRenderer sp;
    private void Awake()
    {
        blackholes = FindObjectsOfType<BlackHole>();
        sp = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    private void OnEnable()
    {
        sp.color = new Color(1f, 1f, 1f, 1f);
        startTime = Time.time;
        speed = Random.Range(minSpeed,maxSpeed);
        currentSpeed = speed;
        Invoke("destroy", 1f);
    }
    private void OnDisable()
    {
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
        sp.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(1, 0, t));
        transform.localScale = new Vector2(transform.localScale.x, Mathf.SmoothStep(1.94f, 0, t));
    }
    private void move()
    {
        if (currentSpeed > 0)
        {
            currentSpeed -= Time.deltaTime * 10f;
        }
        else
        {
            currentSpeed += Time.deltaTime * 2f;
        }
        transform.Translate(Vector3.up * Time.deltaTime * currentSpeed);
        if (!sp.IsVisibleFrom(Camera.main))
        {
            currentSpeed = -1 * speed;
        }
    }
    public void orbit(Transform target, Vector3 dir, float orbitDistance, float speed, float orbitCoffiency)
    {
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 5 * Time.deltaTime);
        transform.position = target.transform.position + (transform.position - target.transform.position).normalized * orbitDistance;
        transform.RotateAround(target.transform.position, Vector3.forward, orbitCoffiency * speed * Time.deltaTime);
    }
    void blackholeInteract() {
        foreach(BlackHole blackhole in blackholes){

        }
    }
}

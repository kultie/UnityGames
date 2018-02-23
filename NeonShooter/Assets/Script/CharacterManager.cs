using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {
    public int currentHP;
    public int maxHP;

    SpriteRenderer sp;
    public Vector3 startColor;
    public ObjectPooler particlePool;

    private void Awake()
    {
        particlePool = GameObject.Find("ParticlePool").GetComponent<ObjectPooler>();
        sp = GetComponent<SpriteRenderer>();
        startColor = new Vector3(sp.color.r, sp.color.g, sp.color.b);
        currentHP = maxHP;
    }
    public void takeDamage(int damage) {
        currentHP -= damage;
    }
    public void behavior() {
        if (currentHP <= 0) {
            dead();
        }
    }
    void dead() {
        for (int i = 0; i < 30; i++)
        {
            GameObject obj = particlePool.getPooledObject();
            if (obj == null) return;
            obj.GetComponent<Particle>().setColor(startColor, 1f);
            obj.transform.position = transform.position;
            obj.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
            obj.SetActive(true);
        }
        gameObject.SetActive(false);
    }
    public void orbit(Transform target, Vector3 dir, float orbitDistance, float speed, float orbitCoffiency)
    {
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 5 * Time.deltaTime);
        transform.position = target.transform.position + (transform.position - target.transform.position).normalized * orbitDistance;
        transform.RotateAround(target.transform.position, Vector3.forward, orbitCoffiency * speed * Time.deltaTime);
    }
    private void Update()
    {
        behavior();
    }
}

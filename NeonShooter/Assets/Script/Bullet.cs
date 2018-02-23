using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    ObjectPooler particlePool;
    public Grid grid;
    SpriteRenderer sp;
    public float speed;

    ObjectManager oManager;

    private void Awake()
    {
        oManager = GetComponent<ObjectManager>();
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        sp = GetComponent<SpriteRenderer>();
        particlePool = GameObject.Find("BulletParticlePool").GetComponent<ObjectPooler>();

    }
    private void OnEnable()
    {
        transform.localScale = Vector3.one;
    }
    public int damage;
    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        grid.ApplyExplosiveForce(0.5f * speed, transform.position, 2.5f);
        if (Mathf.Abs(transform.position.y) > 4.8 || Mathf.Abs(transform.position.x) > 6.5)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject obj = particlePool.getPooledObject();
                if (obj == null) return;
                obj.GetComponent<Particle>().setColor(new Vector3(1f, 1f, 1f), 1f);
                obj.transform.position = transform.position;
                obj.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                obj.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<CharacterManager>().takeDamage(damage);
            oManager.destroy();
        }
    }
}

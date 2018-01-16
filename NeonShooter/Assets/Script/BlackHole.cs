using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float force;
    public float radius;
    public float deadRadius;


    private void Update()
    {
        foreach (Collider2D col in Physics2D.OverlapCircleAll(transform.position, radius))
        {
            Vector3 relativePos = transform.position - col.transform.position;
            float relativePosMagnitude = relativePos.magnitude;
            relativePos.Normalize();
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;

            if (col.gameObject.tag == "Bullet")
            {
                col.GetComponent<PlayerBullet>().bulletSpeed = 4;
                //col.transform.rotation = Quaternion.Slerp(col.transform.rotation, Quaternion.Euler(0f, 0f, angle - 90), 50*Time.deltaTime);
                //col.transform.rotation = Quaternion.RotateTowards(col.transform.rotation, Quaternion.Euler(0f, 0f, angle - 90), 50*Time.deltaTime);
                col.transform.rotation = Quaternion.Lerp(col.transform.rotation, Quaternion.Euler(0f, 0f, angle - 90), 15 * Time.deltaTime);
                col.GetComponent<Rigidbody2D>().AddExplosionForce(force, transform.position, radius);
                if (relativePosMagnitude <= deadRadius)
                {
                    Destroy(col.gameObject);
                }
            }
            else
            {
                col.GetComponent<Rigidbody2D>().AddExplosionForce(force, transform.position, radius);
            }
        }
    }
}

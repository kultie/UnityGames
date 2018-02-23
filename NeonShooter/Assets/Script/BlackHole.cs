using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float force;
    public float radius;
    public float deadRadius;

    Grid grid;

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grid = FindObjectOfType<Grid>().GetComponent<Grid>();
    }
    private void Update()
    {
        float relativeMassCoffiency = 0;
        grid.ApplyImplosiveForce(2f,transform.position,1.5f);
        foreach (Collider2D col in Physics2D.OverlapCircleAll(transform.position, radius))
        {
            
            Rigidbody2D colRb = col.GetComponent<Rigidbody2D>();
            if (colRb != null)
            {
                relativeMassCoffiency = colRb.mass / rb.mass;
            }
            Vector3 relativePos = transform.position - col.transform.position;
            float relativePosMagnitude = relativePos.magnitude;
            relativePos.Normalize();
 

            if (col.gameObject.tag == "Bullet")
            {
                col.GetComponent<Bullet>().enabled = false;
                col.GetComponent<ObjectManager>().orbit(transform, Vector3.forward, relativePosMagnitude -= (Time.deltaTime*2), 
                    force * (rb.mass / colRb.mass) * 1 / relativePosMagnitude, (1 / relativeMassCoffiency) + Time.deltaTime);
                col.transform.localScale = Vector3.one * relativePosMagnitude / radius;
                if (relativePosMagnitude <= deadRadius)
                {
                    col.GetComponent<ObjectManager>().destroy();
                    col.GetComponent<Bullet>().enabled = true;
                }
            }
            else if (col.gameObject.tag == "Player")
            {
                col.GetComponent<CharacterManager>().orbit(transform, Vector3.forward, 
                    relativePosMagnitude -= Time.deltaTime * relativeMassCoffiency, force * (rb.mass / colRb.mass) * 1 / relativePosMagnitude, (1 / relativeMassCoffiency) + Time.deltaTime);
                col.transform.localScale = Vector3.one * relativePosMagnitude / radius;
                if (col.transform.localScale.magnitude > 1)
                {
                    col.transform.localScale = Vector3.one;
                }
            }
            else if (col.gameObject.tag == "normalParticle") {
                col.GetComponent<Particle>().orbit(transform, Vector3.forward, relativePosMagnitude -= Time.deltaTime * 5, force/ relativePosMagnitude, (1 / 5) + Time.deltaTime);
            }
        }
    }
}

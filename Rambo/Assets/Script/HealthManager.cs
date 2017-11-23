using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {
    public int maxHealth;
    public int currentHealth;

    public PlayerControlv2 player;

    public float invulLength;
    private float invulCounter;

    Renderer pRend;
    float flashCounter;
    public float flashLength;

    private void Start()
    {
        currentHealth = maxHealth;
        player = GetComponent<PlayerControlv2>();
        pRend = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (invulCounter > 0)
        {
            invulCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                pRend.enabled = !pRend.enabled;
                flashCounter = Random.Range(flashLength / 5, flashLength*2);
            }
        }
        if (invulCounter <= 0) {
            pRend.enabled = true;
        }
    }

    public void hurt(int damage) {
        if (invulCounter <= 0)
        {
            currentHealth -= damage;
            player.knockbackCount = player.knockbackLength;
            invulCounter = invulLength;

            pRend.enabled = false;
            flashCounter = flashLength;
        }
    }
    public void heal(int health) {
        currentHealth += health;
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
    }
}

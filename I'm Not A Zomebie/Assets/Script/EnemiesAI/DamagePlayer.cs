using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {
    PlayerController player;
    public float staggerTimePerAttack;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Debug.Log("Ouch");
            player.staggerTimeCounter = staggerTimePerAttack;
        }
    }
}

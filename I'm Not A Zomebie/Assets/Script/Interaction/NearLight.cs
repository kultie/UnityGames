using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearLight : MonoBehaviour {
    PlayerInteraction playerInter;
    // Use this for initialization
    private void Start()
    {
        playerInter = FindObjectOfType<PlayerInteraction>();
    }

}

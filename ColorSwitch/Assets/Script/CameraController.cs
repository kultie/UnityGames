﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.y > transform.position.y)
        {
            transform.position = new Vector3(0f, player.transform.position.y, transform.position.z);
        }
	}
}

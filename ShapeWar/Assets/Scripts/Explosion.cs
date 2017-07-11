using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float timeLive;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, timeLive);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

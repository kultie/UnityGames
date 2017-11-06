using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePlatform : MonoBehaviour {
    public Transform telePoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy") {
            other.transform.position = telePoint.transform.position;
        }
    }
}

using UnityEngine;
using System.Collections;

public class Active : MonoBehaviour {
	private Gunner Enemy;
	// Use this for initialization
	void Start () {
		Enemy = FindObjectOfType <Gunner>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		Enemy.shoot ();
		Enemy.shooting = true;
	}
}

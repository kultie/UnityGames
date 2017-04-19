using UnityEngine;
using System.Collections;

public class DestroyObjectOvertime : MonoBehaviour {

	public float lifeTime; //For objects that have lifeTime so they would be destroy ex: bullet, kunai,....

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lifeTime -= Time.deltaTime;
		if (lifeTime <= 0) {
			Destroy(gameObject);
		} 

	}
}

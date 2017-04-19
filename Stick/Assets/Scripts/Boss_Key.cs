using UnityEngine;
using System.Collections;

public class Boss_Key : MonoBehaviour {//Big bad boss guarding this, defeate him then this script will show the magic
	private bool isLive;
	public GameObject reference;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var bossHP = GetComponent<EnemyManager> ().enemyHP;
		if (bossHP <= 0) {
			Destroy(reference.gameObject);
			Debug.Log ("Dafuq");
		}
	}
}

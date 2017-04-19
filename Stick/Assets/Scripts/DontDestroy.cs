using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {//For objects that dont need to be destroy ex: Player, camera

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

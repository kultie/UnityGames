using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 0.05f);
	}
}

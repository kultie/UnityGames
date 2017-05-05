using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour {
    public float rotateSpeed = 100f;

	// Update is called once per frame
	void Update () {
        transform.Rotate(0f, this.transform.position.x, rotateSpeed * Time.deltaTime);
	}
}

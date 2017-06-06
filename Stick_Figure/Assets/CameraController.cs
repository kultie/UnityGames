using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject Target;
	public float speed;
	Vector3 TargetPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		TargetPos = new Vector3(Target.transform.position.x, Target.transform.position.y, -10);
		transform.position = Vector3.Lerp (transform.position, TargetPos, speed *  Time.deltaTime);
	}
}

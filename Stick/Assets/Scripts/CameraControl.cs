using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {//Controlling camera when you alive
	public PlayerController player;
	public bool isFollowing;

	public float xOffset;
	public float yOffset;
	void Awake(){
		DontDestroyOnLoad (this.gameObject);
	}
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> (); //Finding player

		isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isFollowing) {
			transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, player.transform.position.z - 2f);
		}
	}
}

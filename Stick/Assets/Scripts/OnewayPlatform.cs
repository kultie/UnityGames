using UnityEngine;
using System.Collections;

public class OnewayPlatform : MonoBehaviour {//The sciprt for the platforms player can jump form below
	private bool under = false;//bool for if player is under the platform
	public Transform footCheck;//check where the foot
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (footCheck.transform.position.y <= this.transform.position.y) {//compare the pos of platform and player's foot
			under = true;
		} else
			under = false;
		if (under) {//The magic in this script :wuuuooo:
			this.collider2D.enabled = false;
		} else {
			this.collider2D.enabled = true;
		}
	}
}

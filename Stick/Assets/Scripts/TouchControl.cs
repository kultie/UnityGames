using UnityEngine;
using System.Collections;

public class TouchControl : MonoBehaviour {//Script for control the touch buttons on APK file
	private PlayerController thePlayer;
	private LevelLoader lvl;
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		lvl = FindObjectOfType<LevelLoader> ();
	}
	//Left and Right for moving
	public void LeftArrow(){
		thePlayer.moving (-1f);
	}
	public void RightArrow(){
		thePlayer.moving (1f);
	}
	public void unpressArrow(){//When you release your fingers
		thePlayer.moving (0);
	}
	public void Jump(){//Jump to the sky
		thePlayer.Jump ();
	}
	public void Melee(){//Draw Sword to melee
		thePlayer.meleePressed ();
	}
	public void Kunai(){//press to throwing deadly kunai
		thePlayer.Throwing ();
	}
	public void KunaiUnPress(){//not tapping the kunai anymore
		thePlayer.ThrowingUnPress ();
	}
}

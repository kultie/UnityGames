using UnityEngine;
using System.Collections;

public class toMenu : MonoBehaviour {//To menu when credits end
	private Animation anim;
	// Use this for initialization
	void Awake(){
	}
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine ("endCredits");
	}
	IEnumerator endCredits(){
		yield return new WaitForSeconds(33);
		Application.LoadLevel ("Title");
	}
}

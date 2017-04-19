using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KunaiCounter : MonoBehaviour {//this script controll the showing of current kunai you help
	public static int kunaiCounter;
	public static int currentCounter;

	// Use this for initialization
	Text text;
	
	void Start(){//setting up for the text
		text = GetComponent<Text> ();
		
		kunaiCounter = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if (kunaiCounter <= 0) {//if amount of kunai is <= 0 set it to zero and you gonna have a bad time with bigger enemy
			kunaiCounter = 0;
		}
		text.text = "" + kunaiCounter;
	}
	public static void AddKunai(int amount){//Add kunai when pick power-up = The "Kunai charger" script
		kunaiCounter += amount;
		currentCounter = kunaiCounter;
	}
	//public static void Reset(){
		//kunaiCounter = 0;
	//}
	void OnTriggerEnter2D(Collider2D other){//this just for testing the destroy but still very important
		Destroy (gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceCharger : MonoBehaviour {
    public float forceCounter;
    private float forceMax = 100;

    public PlayerController player;

    public Slider powerBar;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        powerBar = GetComponent<Slider>();
        forceCounter = 0;
        powerBar.maxValue = player.maxJumpForce;
	}
	
	// Update is called once per frame
	void Update () {
        forceCounter = player.currentJumpForce;
        powerBar.value = forceCounter;
	}
}

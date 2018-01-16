using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {
    public int currentHP;
    public int maxHP;

    public Transform respawnPoint;

	
	// Update is called once per frame
	void Update () {
		
	}
    public void takeDamage(int damage) {
        currentHP -= damage;
    }
    public void behavior() {
        if (currentHP <= 0) {
            dead();
        }
    }
    void dead() {

    }
}

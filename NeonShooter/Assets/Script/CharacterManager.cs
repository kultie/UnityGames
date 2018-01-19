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
    public void orbit(Transform target, Vector3 dir, float orbitDistance, float speed, float orbitCoffiency)
    {
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 5 * Time.deltaTime);
        transform.position = target.transform.position + (transform.position - target.transform.position).normalized * orbitDistance;
        transform.RotateAround(target.transform.position, Vector3.forward, orbitCoffiency * speed * Time.deltaTime);
    }
}

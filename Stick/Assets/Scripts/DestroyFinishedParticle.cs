using UnityEngine;
using System.Collections;

public class DestroyFinishedParticle : MonoBehaviour { //This for destroy any particle that finish showing
	private ParticleSystem thisParticleSystem;
	// Use this for initialization
	void Start () {
		thisParticleSystem = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (thisParticleSystem.isPlaying)
			return;
		Destroy (gameObject);
	}
	void OnBecameInvisile(){
		Destroy (gameObject);
	}
}

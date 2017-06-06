using UnityEngine;
using System.Collections;

public class Gunner : MonoBehaviour {
	public GameObject gunPoint;
	public GameObject Bullet;
	public float Timer;
	public float maxTimeShooting;
	public float MinTimeShooting;
	public bool shooting = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			shoot ();

		}
	public void shoot(){
		Timer -= Time.deltaTime;
		if (Timer <= 0) {
			Instantiate (Bullet, gunPoint.transform.position, Quaternion.identity);
			Timer = Random.Range (MinTimeShooting, maxTimeShooting);
			}
		}
}

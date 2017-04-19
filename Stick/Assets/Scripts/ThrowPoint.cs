using UnityEngine;
using System.Collections;

public class ThrowPoint : MonoBehaviour {//Wher will the kunai spawn?
	public Transform throwPoint;
	public GameObject Kunai;
	public void Shooting(){
		Instantiate (Kunai, throwPoint.transform.position, Quaternion.identity);
	}
}

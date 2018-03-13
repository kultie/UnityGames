using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Button : MonoBehaviour {
	public GameObject unit;
	public void spawnUnit2(){
		Transform spawnRoot = GameObject.Find ("Start").transform;
		for (int i = 0; i < 20; i++)
		{
			Instantiate(unit, spawnRoot.position, Quaternion.identity);
		}
	}
	public void spawnUnit5(){
		Transform spawnRoot = GameObject.Find ("Start").transform;
		for (int i = 0; i < 50; i++)
		{
            Instantiate(unit, spawnRoot.position, Quaternion.identity);
        }
	}
	public void spawnUnit10(){
		Transform spawnRoot = GameObject.Find ("Start").transform;
		for (int i = 0; i < 100; i++)
		{
            Instantiate(unit, spawnRoot.position, Quaternion.identity);
        }
	}
	Vector3 RandomCircle(Vector3 center, float radius)
	{
		float ang = Random.Range (0,360);
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Abs(Mathf.Sin(ang * Mathf.Deg2Rad));
		pos.y = center.y + radius * Mathf.Abs(Mathf.Cos(ang * Mathf.Deg2Rad));
		pos.z = center.z;
		return pos;
	}
}

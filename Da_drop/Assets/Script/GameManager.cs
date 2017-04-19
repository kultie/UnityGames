﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public float slowness = 10f;

	public void EndGame()
	{
		StartCoroutine (RestartLevel ());
	}
	IEnumerator RestartLevel()
	{
		Time.timeScale = 1f / slowness;
		Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
		// before 1 sec
		yield return new WaitForSeconds(1f / slowness);

		Time.timeScale = 1f;
		Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
		//after 1sec
		Application.LoadLevel ("level1");
	}
}


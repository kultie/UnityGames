using UnityEngine;

public class BlockSpawner : MonoBehaviour {
	public Transform[] spawnPoints;
	public GameObject blockPref;
	public int Score = 0;
	private GUIStyle guiStyle = new GUIStyle ();
	
	public float timeBetweenWaves = 1f;
	private float timeToSpawn = 2f;
	// Use this for initialization
	void Update () {
		if (Time.time >= timeToSpawn) 
		{
			SpawnBlocks ();
			timeToSpawn = Time.time + timeBetweenWaves;
			Score += 1 ;
		}
	}
	void SpawnBlocks()
	{ 
		int randomIndex = Random.Range (0, spawnPoints.Length);
		
		for (int i =0; i< spawnPoints.Length; i++) 
		{
			if(randomIndex != i)
			{
				Instantiate(blockPref, spawnPoints[i].position, Quaternion.identity);
			}
		}
	}
	void OnGUI()
	{
		GUI.color = Color.white;
		guiStyle.fontSize = 20;
		GUILayout.Label ("Score: " + Score , guiStyle);
	}

}

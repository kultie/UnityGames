public var obj: GameObject[];
public var spawnMin: float;
public var spawnMax: float;
	
	function Start () {
		//start spawn 
		Spawn ();
	}
	
	function Spawn(){
		//get random number
		var rand : float;
		rand = Random.Range (0,100);
		if (rand > 70) {
			Instantiate (obj [Random.Range (0, obj.GetLength (0))], transform.position, Quaternion.identity);
		}
		//invoke spawn at random time interval between min and max
		Invoke ("Spawn", Random.Range (spawnMin, spawnMax));
	}

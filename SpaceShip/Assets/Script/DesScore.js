public var Health: int;
function Start () {
		
	}
function update(){
}	
function OnTriggerEnter2D(other){
		//if the object that triggered the event is tagged player
		if (other.tag == "Asteroid") {
			Destroy (other.gameObject);	
			Health = Health-1;
			if (Health == 0){
				Debug.Break ();
				return;
			}
			}
			}
function OnGUI(){
	GUI.color = Color.white;
	GUILayout.Label("Health: "+Health);
}	
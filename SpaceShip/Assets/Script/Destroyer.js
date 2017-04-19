
function Start () {
		
	}
function update(){
}
function OnTriggerEnter2D(other){
		//if the object that triggered the event is tagged player
		if (other.tag == "Player") {
			
			Debug.Break ();
			return;
		} else {
			Destroy (other.gameObject);	
			}
			}
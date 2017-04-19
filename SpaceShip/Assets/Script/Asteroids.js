import UnityEngine.UI;
public var speed: float;
function Start () {
}

function Update () {
	rigidbody2D.velocity = new Vector3 (speed, rigidbody2D.velocity.y);
}
function OnTriggerEnter2D(other){
		if (other.tag == "Player") {
			
			Destroy(other.gameObject);
			return;
		}
		if (other.tag == "Bullet") {
			Destroy(other.gameObject);	
			Destroy(this.gameObject);
		}
		}
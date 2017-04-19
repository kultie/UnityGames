private var player: Controller;
public var speed: float;
function Start () {
	player = FindObjectOfType(Controller);
}

function Update () {
	rigidbody2D.velocity = new Vector3 (speed, rigidbody2D.velocity.y);
}
function OnTriggerEnter2D(other){
		if (other.tag == "Player") {
			Destroy(this.gameObject);
			player.bullet += 5;
		}
		}
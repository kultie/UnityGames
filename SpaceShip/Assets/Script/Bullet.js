public var speed: float;
	// Use this for initialization
	function Start () {
	
	}
	
	// Update is called once per frame
	function Update () {
		rigidbody2D.velocity = new Vector3 (speed, rigidbody2D.velocity.y);
	
	}
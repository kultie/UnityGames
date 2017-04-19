public var obj: GameObject;
public var speed:float ;
public var bullet: int;
	// Use this for initialization
	function Start () {
	}
	// Update is called once per frame
	function Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
						rigidbody2D.velocity = new Vector3 (rigidbody2D.velocity.x, speed);
				}
		if(bullet >0){
		if (Input.GetKeyDown (KeyCode.Z)) {
			Instantiate(obj, transform.position, Quaternion.identity);	
			bullet = bullet -1;
		}
		}
	}
function OnGUI(){
	GUI.color = Color.white;
	GUILayout.Label("                    Bullet: " + bullet);
}
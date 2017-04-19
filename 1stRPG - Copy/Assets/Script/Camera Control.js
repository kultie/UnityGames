#pragma strict
var Target: GameObject;
var speed: float;
var TargetPos: Vector3;
function Start () {

}

function Update () {
	TargetPos = new Vector3(Target.transform.position.x, Target.transform.position.y, -10);
	transform.position = Vector3.Lerp (transform.position, TargetPos, speed *  Time.deltaTime);
}
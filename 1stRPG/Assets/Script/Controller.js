var speed: float = 1f;
var anim : Animator;
var Moving: boolean;
var LastMove: Vector2;
public var canMove : boolean;
private var dMan : DialogManager;
function Start () {
 anim = GetComponent("Animator");
 canMove = true;
}

function Update () {
	Moving = false;
	var myRigidbody = GetComponent(Rigidbody2D); 
	if(!canMove){
		myRigidbody.velocity = Vector2.zero;
		return;
	}
	if(canMove){
	horizontal();
	vertical();
	anim.SetFloat("MoveX",Input.GetAxisRaw("Horizontal"));
	anim.SetFloat("MoveY",Input.GetAxisRaw("Vertical"));
	anim.SetBool("Moving",Moving);
	anim.SetFloat("LastMoveX",LastMove.x);
	anim.SetFloat("LastMoveY",LastMove.y);}
	
}
function horizontal(){
	if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f ){
		transform.Translate( Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime , 0f , 0f);
		Moving = true;
		LastMove = new Vector2(Input.GetAxisRaw("Horizontal") , 0f);
	}
}
function vertical(){
	if(Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f){
		transform.Translate( 0f , Input.GetAxisRaw("Vertical") * speed * Time.deltaTime , 0f);
		Moving = true;
		LastMove = new Vector2(0f , Input.GetAxisRaw("Vertical"));
	}
}

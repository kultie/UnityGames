using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	//This will be our maximum speed as we will always be multiplying by 1
	public float maxSpeed = 2f;
	public GameObject punchPoint;
	public Transform Player;
	//a boolean value to represent whether we are facing left or not
	bool facingLeft = false;
	bool moving = false;
	//a value to represent our Animator
	Animator anim;
	//to check ground and to have a jumpforce we can change in the editor
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	bool punching = true;
	bool crounch = false;
	private float speed; 
	float timer;
	public float attackTime;
	private float attackTimeCounter;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	private Vector3 pos;
	
	// Use this for initialization
	void Start () {
		//set anim to our animator
		anim = GetComponent <Animator>();
		speed = maxSpeed;
		Player = transform;
		
	}
	
	
	void FixedUpdate () {
		//set our vSpeed
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		//set our grounded bool
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		//set ground in our Animator to match grounded
		anim.SetBool ("Ground", grounded);
		anim.SetBool ("Moving", moving);
		anim.SetBool ("Crounch", crounch);
		if (!punching) {
			if (Input.GetAxis ("Horizontal") > 0f || Input.GetAxis ("Horizontal") < 0f) {
				anim.SetBool ("Moving", true);
				float move = Input.GetAxis ("Horizontal");//Gives us of one if we are moving via the arrow keys
				//move our Players rigidbody
				rigidbody2D.velocity = new Vector3 (move * maxSpeed, rigidbody2D.velocity.y);	
				//set our speed
				anim.SetFloat ("Speed", Mathf.Abs (move));
		
				//if we are moving left but not facing left flip, and vice versa
				if (move < 0 && !facingLeft) {
			
					Flip ();
				} else if (move > 0 && facingLeft) {
					Flip ();
				}
			}
		}
	}
	
	void Update(){
		//if we are on the ground and the space bar was pressed, change our ground state and add an upward force
		if(grounded && Input.GetKeyDown (KeyCode.Space)){
			anim.SetBool("Ground",false);
			rigidbody2D.AddForce (new Vector2(0,jumpForce));
		}
		if(Input.GetKey(KeyCode.Z)){
			attackTimeCounter = attackTime;
			punching = true;
			anim.SetBool ("Punch",true);
			punchPoint.collider2D.enabled = true;
			anim.SetFloat ("Speed",0f);
		}
		if (attackTimeCounter > 0) {
			attackTimeCounter -= Time.deltaTime;
		}
		if (attackTimeCounter <= 0) {
			punching = false;
			anim.SetBool("Punch",false);
			punchPoint.collider2D.enabled = false;
		}
		if (!crounch && Input.GetKeyDown (KeyCode.X)) {
			crounch = true;
			timer = 2f;
			anim.SetBool("Crounch",true);
			anim.SetFloat("Timer",timer);
			maxSpeed = 0f;
			pos.x=Player.position.x;
			pos.z= Player.position.z;
			pos.y = Player.position.y - 0.5f;
			Player.position = pos; 
		}
		if (crounch && Input.GetKeyUp (KeyCode.X)) {
			anim.SetBool("Crounch",false);
			crounch = false;
			maxSpeed = speed;
		}
		
	}
	
	//flip if needed
	void Flip(){
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
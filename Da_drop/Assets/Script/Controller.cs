using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public float speed ;
	private Rigidbody2D rb;
	public float MapWidth = 10f;
	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = Input.GetAxisRaw ("Horizontal") * Time.fixedDeltaTime * speed;
		Vector2 newPosition = rb.position + Vector2.right * x;
		newPosition.x = Mathf.Clamp (newPosition.x, -MapWidth, MapWidth);
		rb.MovePosition (newPosition);
		}
	void OnCollisionEnter2D()
	{
		Debug.Log ("abcd");
		FindObjectOfType<GameManager>().EndGame();
	}
	}


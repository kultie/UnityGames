using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {


    public float maxJumpForce = 20f;
    public float currentJumpForce;
    public float jumpForceScale = 10f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    string currentColor;

    public Color colorYellow;
    public Color colorBlue;
    public Color colorRed;
    public Color colorViolet;

    bool maxForce;
    bool minForce;
    // Use this for initialization
    void setRandomColor()
    {
        int colorIndex = Random.Range(0, 4);
        switch (colorIndex)
        {
            case 0:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 1:
                currentColor = "Blue";
                sr.color = colorBlue;
                break;
            case 2:
                currentColor = "Red";
                sr.color = colorRed;
                break;
            case 3:
                currentColor = "Violet";
                sr.color = colorViolet;
                break;
        }
    }

    void forceState() {
        if (currentJumpForce >= maxJumpForce)
        {
            maxForce = true;
            minForce = false;
        }
        if (currentJumpForce <= 0)
        {
            maxForce = false;
            minForce = true;
        }
    }
    void forceCharger() {
        if (maxForce)
        {
            currentJumpForce += jumpForceScale * Time.deltaTime * -1;
        }
        if (minForce)
        {
            currentJumpForce += jumpForceScale * Time.deltaTime;
        }
    }
    void Start () {
        setRandomColor();
	}
	// Update is called once per frame
	void Update () {
        forceState();
        if (Input.GetKey(KeyCode.Space))
        {
            rb.bodyType = RigidbodyType2D.Static;
            forceCharger();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;           
            rb.velocity = Vector2.up * currentJumpForce;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "ColorChanger") {
            setRandomColor();
            Destroy(col.gameObject);
            Score.AddPoints(1);
            return;
        }
        if(col.tag != currentColor)
        {
            Debug.Log("GameOver");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    public GameObject shadow;
    public SpriteRenderer sRend;
    // Use this for initialization
    private void Start()
    {
        sRend = shadow.GetComponent<SpriteRenderer>();
    }
	public void activeShadow()
    {
        sRend.enabled = true;
    }
    public void deActiveShadow()
    {
        sRend.enabled = false;
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "LightZone")
        {
            activeShadow();
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "LightZone")
        {
            deActiveShadow();
        }
    }
}

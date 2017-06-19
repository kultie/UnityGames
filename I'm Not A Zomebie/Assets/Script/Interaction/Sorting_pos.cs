using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorting_pos : MonoBehaviour {
    Rigidbody2D rb;
    SpriteRenderer sRend;
    // Use this for initialization
    private void Start()
    {
        sRend = GetComponent<SpriteRenderer>();
    }
    private void Update()
    { 
        sRend.sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
        if(Mathf.RoundToInt(transform.position.y * 100f) * -1 < 1)
        {
            sRend.sortingOrder = 1;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBullet : MonoBehaviour {
    public GameObject explosion;
    // Update is called once per frame
    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }
}

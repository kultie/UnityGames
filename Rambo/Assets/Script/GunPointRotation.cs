using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPointRotation : MonoBehaviour {
    public float randomRot;
    // Update is called once per frame
    void Update () {
        transform.localRotation = Quaternion.identity;
        transform.Rotate(0, 0, Random.Range(-randomRot, randomRot));
    }
}

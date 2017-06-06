using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject pinPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPin();
        }
    }
    void SpawnPin()
    {
        Instantiate(pinPrefab, transform.position, transform.rotation);
    }
}

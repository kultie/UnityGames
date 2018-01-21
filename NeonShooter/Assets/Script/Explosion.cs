using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public ObjectPooler particlePool;

    float timeCounter;
    public float timer;
    void Start()
    {
        timeCounter = timer;
    }
    private void Update()
    {
        if (timeCounter <= 0)
        {
            for (int i = 0; i < 30; i++)
            {
                GameObject obj = particlePool.getPooledObject();
                if (obj == null) return;
                obj.transform.position = transform.position;
                obj.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                obj.SetActive(true);
            }
            timeCounter = timer;
        }
        else {
            timeCounter -= Time.deltaTime;
        }
    }
}

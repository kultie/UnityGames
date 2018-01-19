using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {
    public static ObjectPooler currentPool;
    public GameObject pooledObj;
    public int poolSize = 20;

    public bool expandable = true;

    public List<GameObject> pooledObjs;

    void Awake() {
        currentPool = this;
    }

    private void Start()
    {
        pooledObjs = new List<GameObject>();
        for (int i = 0; i < poolSize; i++) {
            GameObject obj = (GameObject)Instantiate(pooledObj);
            obj.SetActive(false);
            pooledObjs.Add(obj);
        }
    }
    public GameObject getPooledObject() {
        for (int i = 0; i < pooledObjs.Count; i++) {
            if (!pooledObjs[i].activeInHierarchy) {
                return pooledObjs[i];
            }
        }

        if (expandable) {
            GameObject obj = (GameObject)Instantiate(pooledObj);
            pooledObjs.Add(obj);
            return obj;
        }

        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {  
    SpriteRenderer sp;
    public void destroy()
    {
        gameObject.SetActive(false);
    }
    private void Start()
    {

        sp = GetComponent<SpriteRenderer>();
    }
    public void orbit(Transform target, Vector3 dir, float orbitDistance, float speed, float orbitCoffiency) {
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 5 * Time.deltaTime);
        transform.position = target.transform.position + (transform.position - target.transform.position).normalized * orbitDistance;
        transform.RotateAround(target.transform.position, Vector3.forward, orbitCoffiency * speed * Time.deltaTime);
    }
    private void Update()
    {
        if (transform.localScale.x <= 0 || transform.localScale.y <= 0)
        {
            destroy();
        }
        if (Mathf.Abs(transform.position.x) > 10 || Mathf.Abs(transform.position.y) > 5) {
            destroy();
        }
    }
}

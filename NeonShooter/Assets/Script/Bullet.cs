using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int damage;
    public void bulletAction(float speed) {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    public void destroy(SpriteRenderer sprite)
    {
        if (!sprite.isVisible)
        {
            Destroy(gameObject);
        }
    }
}

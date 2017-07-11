using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject respawnPoint;

    public CircleController activedPlayer;
    private void Start()
    {
        activedPlayer = FindObjectOfType<CircleController>();
    }

    public void respawn() {
        StartCoroutine(respawnPlayer());
    }
    private IEnumerator respawnPlayer()
    {
        activedPlayer.enabled = false;
        activedPlayer.GetComponent<Renderer>().enabled = false;
        activedPlayer.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(2f);
        activedPlayer.transform.position = this.transform.position;
        activedPlayer.enabled = true;
        activedPlayer.GetComponent<Renderer>().enabled = true;
        activedPlayer.GetComponent<Collider2D>().enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private bool gameEnded = false;

    public Rotator rotator;
    public Spawner spawner;

    public Animator anim;
	public void endGame()
    {
        if (gameEnded)
        {
            return;
        }

        rotator.enabled = false;
        spawner.enabled = false;
        anim.SetTrigger("GameEnded");
        gameEnded = true;
    }
}

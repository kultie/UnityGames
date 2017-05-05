using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public static float score;
    public static float currentScore;

    Text text;

    void Start()
    {
        text = GetComponent<Text>();

        currentScore = 0;
    }
    void Update()
    {//Text on the UI
        score = currentScore;
        text.text = "" + score;
    }

    public static void AddPoints(float points)
    {//Adding score if requirement is met
        currentScore += points;
    }
}

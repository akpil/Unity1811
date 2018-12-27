using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public UIController uiControl;
    private int currentScore;
    private const int PASS_SCORE = 5;
	// Use this for initialization
	void Start () {
        currentScore = 0;
	}

    public void AddScore(int amount)
    {
        currentScore += amount;
        Debug.Log(currentScore);
        if (currentScore >= PASS_SCORE)
        {
            uiControl.GameFinish();
        }
        else
        {
            uiControl.ShowScore(currentScore);
        }
    }
}

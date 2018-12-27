using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text ScoreText;

    public void ShowScore(int score)
    {
        ScoreText.text = string.Format("Score : {0}", score.ToString());
    }

    public void GameFinish()
    {
        ScoreText.color = Color.red;
        ScoreText.text = "Game Finish";
    }
}

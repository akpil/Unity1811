using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text ScoreText, GameStatusText;
    public Button RestartButton;
    public Image HPBar;
    int id;
	// Use this for initialization
	void Start () {
        ScoreText.text = "Score : 0";
        GameStatusText.text = "";
        //RestartButton.onClick.AddListener(GameController.instance.Restart);
        
    }

    public void ShowHP(float amount)
    {
        HPBar.fillAmount = amount;
    }

    public void ShowScore(int value)
    {
        ScoreText.text = string.Format("Score : {0}", value.ToString());
    }

    public void ShowGameStatus(string value)
    {
        GameStatusText.text = value;
    }

	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour {

    [SerializeField]
    private Button StartButton;
    

	// Use this for initialization
	void Start () {
        StartButton.onClick.AddListener(LoadMainGame);
    }

    private void LoadMainGame()
    {
        SceneManager.LoadScene(1);
    }

	// Update is called once per frame
	void Update () {
		
	}
}

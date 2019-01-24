using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController instance;
    private float maxValue;
    private float currentValue;
    private float gap;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        maxValue = 100;
        currentValue = 0;
        gap = 5;
    }

    public void Touch()
    {
        currentValue += gap;
        if (currentValue > maxValue)
        {
            currentValue = 0;
        }
        UIController.instance.ShowGauge(currentValue/maxValue);
    }

	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public static UIController instance;

    [SerializeField]
    private Image GaugeBar;
    [SerializeField]
    private Text GaugeText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}

    public void ShowGauge(float amount)
    {
        GaugeBar.fillAmount = amount;
        GaugeText.text = amount.ToString("p0");
    }

	// Update is called once per frame
	void Update () {
		
	}
}

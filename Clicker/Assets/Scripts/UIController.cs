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

    [SerializeField]
    private Animator[] SlideWindowAnim;
    public static readonly int windowOpenHash = Animator.StringToHash("IsON");

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

    public void OpenWindow(int id)
    {
        SlideWindowAnim[id].SetBool(windowOpenHash, true);
    }

    public void CloseWindow(int id)
    {
        SlideWindowAnim[id].SetBool(windowOpenHash, false);
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

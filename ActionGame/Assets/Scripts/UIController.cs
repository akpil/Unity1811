using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public static UIController instance;

    [SerializeField]
    private Text moneyText, incomeText;
    [SerializeField]
    private GameObject resultWindow;

    [SerializeField]
    private Image[] HP;
    private int hpPivot;

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

    public void ShowMoney(float money)
    {
        moneyText.text = money.ToString("F1");
    }

    public void ShowResultWindow(float income)
    {
        resultWindow.SetActive(true);
        StartCoroutine(ShowIncomeResult(income));
    }

    private IEnumerator ShowIncomeResult(float money)
    {
        WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();
        float currentShowMoney = 0;
        float moneyAddGap = money / 150;
        while (currentShowMoney < money)
        {
            currentShowMoney += moneyAddGap;
            incomeText.text = currentShowMoney.ToString("F1");
            yield return fixedUpdate;
        }
        incomeText.text = money.ToString("F1");
    }

    // Use this for initialization
    void Start () {
        hpPivot = HP.Length - 1;
    }
	
    public void AddHP(int amount)
    {
        int temp = hpPivot + amount;
        if (hpPivot < HP.Length)
        {
            for (int i = hpPivot; i < temp; i++)
            {
                if (i < HP.Length)
                {
                    HP[i].gameObject.SetActive(true);
                    hpPivot++;
                }
                else
                {
                    break;
                }
            }
            if (hpPivot > HP.Length - 1)
            {
                hpPivot = HP.Length - 1;
            }
        }
    }

    public void SubHP(int amount)
    {
        Debug.Log(amount);
        int temp = hpPivot - amount;
        if (hpPivot >= 0)
        {
            for (int i = hpPivot; i > temp; i--)
            {
                if (i >= 0)
                {
                    HP[i].gameObject.SetActive(false);
                    hpPivot--;
                }
                else
                {
                    break;
                }
            }
            if (hpPivot < 0)
            {
                hpPivot = 0;
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}

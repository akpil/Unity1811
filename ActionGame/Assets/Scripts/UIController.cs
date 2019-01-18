using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public static UIController instance;

    [SerializeField]
    private Text moneyText;

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

    // Use this for initialization
    void Start () {
        hpPivot = HP.Length - 1;
    }
	
    public void AddHP(int amount)
    {
        if (hpPivot < HP.Length - 1)
        {
            for (int i = hpPivot; i < hpPivot + amount; i++)
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
        if (hpPivot > 0)
        {
            for (int i = hpPivot; i < hpPivot - amount; i--)
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

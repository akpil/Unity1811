using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {
    [SerializeField]
    private GameObject hpBarObj;
    [SerializeField]
    private Image hpBar;

    [SerializeField]
    private GameObject incomeObj;
    [SerializeField]
    private Text income;

    private void OnEnable()
    {
        hpBarObj.SetActive(false);
        incomeObj.SetActive(false);
    }

    public void ShowHP(float amount)
    {
        hpBarObj.SetActive(true);
        hpBar.fillAmount = amount;
    }

    public void ShowIncome(float amount)
    {
        incomeObj.SetActive(true);
        income.text = amount.ToString("F1");
    }
}

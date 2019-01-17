using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {

    [SerializeField]
    private Image hpBar;

    public void ShowHP(float amount)
    {
        hpBar.fillAmount = amount;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIelement : MonoBehaviour {

    [SerializeField]
    private Image icon;
    [SerializeField]
    private Text title, cost, contents, purchase;
    [SerializeField]
    private Button purchaseButton;
    private int id;
    public void Init(Sprite inputIcon, string titleText, string costText, string contentsText, string purchaseText)
    {
        icon.sprite = inputIcon;
        title.text = titleText;
        cost.text = costText;
        contents.text = contentsText;
        purchase.text = purchaseText;

    }

    public void Renew(string costText, string contentsText, string purchaseText)
    {
        cost.text = costText;
        contents.text = contentsText;
        purchase.text = purchaseText;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour {
    [SerializeField]
    private Text name, level, contetns, costAndPurchase, costAndPurchase10;
    [SerializeField]
    private Button purchaseButton, purchaseButton10;
    [SerializeField]
    private int id;
    

    public void Init(string inputName, string inputLevel, string inputContents, string cost)
    {
        name.text = inputName;
        level.text = inputLevel;
        contetns.text = inputContents;
        costAndPurchase.text = cost;
        purchaseButton.onClick.AddListener(() => { CoworkersController.instance.LevelUP(id, Renew); });
    }

    public void Renew(string inputLevel, string inputContents, string cost)
    {
        level.text = inputLevel;
        contetns.text = inputContents;
        costAndPurchase.text = cost;
    }
}

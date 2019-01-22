using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusController : MonoBehaviour {
    [SerializeField]
    private Stat[] infos;
    [SerializeField]
    private Sprite[] icons;
    [SerializeField]
    private UIelement[] elements;


    private void Awake()
    {
        infos = new Stat[2];
        infos[0] = new Stat();
        infos[0].iconId = 0;
        infos[0].name = "공격력 증가";
        infos[0].contents = "플레이어의 공격력을 <color=black>{0}</color>로 향상시킵니다.";
        infos[0].currentLevel = 0;
        infos[0].maxLevel = 500;

        infos[0].costBase = 100;
        infos[0].costWeight = 1.07f;
        infos[0].costCurrent = infos[0].costBase * Math.Pow(infos[0].costWeight, infos[0].currentLevel);
        infos[0].valueBase = 1;
        infos[0].valueWeight = 1.04f;
        infos[0].valueCurrent = infos[0].costBase * Math.Pow(infos[0].valueWeight, infos[0].currentLevel);

        infos[1] = new Stat();
        infos[1].iconId = 1;
        infos[1].name = "체력 증가";
        infos[1].contents = "플레이어의 체력을 <color=black>{0}</color>로 향상시킵니다.";
        infos[1].currentLevel = 0;
        infos[1].maxLevel = 500;

        infos[1].costBase = 200;
        infos[1].costWeight = 1.1f;
        infos[1].costCurrent = infos[1].costBase * Math.Pow(infos[1].costWeight, infos[1].currentLevel);
        infos[1].valueBase = 1;
        infos[1].valueWeight = 1.01f;
        infos[1].valueCurrent = infos[1].costBase * Math.Pow(infos[1].valueWeight, infos[1].currentLevel);

        for (int i = 0; i < elements.Length; i++)
        {
            elements[i].Init(icons[infos[i].iconId],
                             infos[i].name,
                             infos[i].costCurrent.ToString("f1"),
                             string.Format(infos[i].contents, infos[i].valueCurrent.ToString("f1")),
                             "구매");
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
[Serializable]
public class Stat
{
    public int iconId;
    public string name;
    public string contents; // format string
    public int currentLevel;
    public int maxLevel;

    public float costBase;
    public float costWeight;
    public double costCurrent;

    public float valueBase;
    public float valueWeight;
    public double valueCurrent;
}
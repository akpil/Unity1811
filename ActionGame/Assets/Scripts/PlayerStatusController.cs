using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatusController : MonoBehaviour {
    [SerializeField]
    private Stat[] infos;
    [SerializeField]
    private Sprite[] icons;
    [SerializeField]
    private UIelement[] elements;

    private float discoutRate;

    private void Awake()
    {
        discoutRate = 0;

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
                             "구매",
                             i,
                             LevelUP);
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeDelegate()
    {
        elements[1].ChangeCallBack((int a) => { Debug.Log(a + "  haha"); });
    }

    // Use this for initialization
    void Start () {
		
	}

    public void AddDiscout(float value)
    {
        discoutRate += value;
        for (int i = 0; i < infos.Length; i++)
        {
            CalcInfo(i);
            elements[i].Renew(infos[i].costCurrent.ToString("f1"),
                              string.Format(infos[i].contents, infos[i].valueCurrent.ToString("f1")),
                              "구매"
                              );
        }
    }

    public void CalcInfo(int id)
    {
        infos[id].costCurrent = infos[id].costBase * Math.Pow(infos[id].costWeight, infos[id].currentLevel) * (1 - discoutRate);
        infos[id].valueCurrent = infos[id].valueBase * Math.Pow(infos[id].valueWeight, infos[id].currentLevel);
    }

    public void LevelUP(int id)
    {
        if (infos[id].currentLevel < infos[id].maxLevel)
        {
            infos[id].currentLevel++;
            CalcInfo(id);

            PlayerData.instance.AddValue1(5.5f);

            string purchaseStr = "";
            if (infos[id].currentLevel < infos[id].maxLevel)
            {
                purchaseStr = "구매";
            }
            else
            {
                purchaseStr = "완료";
            }

            elements[id].Renew(infos[id].costCurrent.ToString("f1"),
                              string.Format(infos[id].contents, infos[id].valueCurrent.ToString("f1")),
                              purchaseStr
                              );
        }
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
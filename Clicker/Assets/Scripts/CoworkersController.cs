using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoworkersController : MonoBehaviour {
    public static CoworkersController instance;
    [SerializeField]
    private CoworkerInfo[] infos;
    [SerializeField]
    private CharacterMovementController[] coworkerPrefab;

    private CharacterMovementController[] activeCoworkers;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            coworkerPrefab = Resources.LoadAll<CharacterMovementController>("Prefab/Colleague");
            activeCoworkers = new CharacterMovementController[coworkerPrefab.Length];
            infos = new CoworkerInfo[3];
            for (int i = 0; i < infos.Length; i++)
            {
                infos[i] = new CoworkerInfo();
                infos[i].id = i;
                infos[i].incomePeriod = 1.5f;
                infos[i].currentLevel = 0;
                infos[i].maxLevel = 5000;
                infos[i].costWeight = 1.08f;
                infos[i].valueWeight = 1.04f;
                infos[i].contents = "업그레이드시 매 {0}초 마다 {1}의 수입을 올려줍니다.";
            }

            infos[0].name = "동료1";
            infos[1].name = "동료2";
            infos[2].name = "동료3";

            infos[0].costBase = 100;
            infos[0].costCurrent = infos[0].costBase;
            infos[1].costBase = 400;
            infos[1].costCurrent = infos[1].costBase;
            infos[2].costBase = 800;
            infos[2].costCurrent = infos[2].costBase;

            infos[0].valueBase = 1;
            infos[0].valueCurrent = infos[0].valueBase;
            infos[1].valueBase = 4;
            infos[1].valueCurrent = infos[1].valueBase;
            infos[2].valueBase = 8;
            infos[2].valueCurrent = infos[2].valueBase;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public string GetIncome(int id)
    {
        GameController.instance.AddMoney(infos[id].valueCurrent);
        return infos[id].valueCurrent.ToString();
    }

    public void LevelUP(int id, Delegate.ElementRenewFunc callback = null)
    {
        if (infos[id].currentLevel < infos[id].maxLevel)
        {
            if (infos[id].currentLevel == 0)
            {
                activeCoworkers[id] = Instantiate(coworkerPrefab[id]);
            }

            infos[id].currentLevel++;
            CalcData(id);
            if (callback != null)
            {
                callback(infos[id].currentLevel.ToString(),
                        string.Format(infos[id].contents, 
                                      infos[id].incomePeriod.ToString("f1"),
                                      infos[id].valueCurrent.ToString()),
                        infos[id].costCurrent.ToString());
            }
        }
    }

    public void CalcData(int id)
    {
        infos[id].costCurrent = infos[id].costBase * 
                        System.Math.Pow(infos[id].costWeight, infos[id].currentLevel);
        infos[id].valueCurrent = infos[id].valueBase *
                        System.Math.Pow(infos[id].valueWeight, infos[id].currentLevel);
    }



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

[System.Serializable]
public class CoworkerInfo
{
    public int id;
    public string name;
    public string contents;
    public int currentLevel;
    public int maxLevel;

    public float costBase;
    public float costWeight;
    public double costCurrent;

    public float valueBase;
    public float valueWeight;
    public double valueCurrent;

    public float incomePeriod;

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class JsonGenenrator : MonoBehaviour {
    [SerializeField]
    private CoworkerInfo[] infos;
    void Start () {
        //infos = new CoworkerInfo[3];
        //for (int i = 0; i < infos.Length; i++)
        //{
        //    infos[i] = new CoworkerInfo();
        //    infos[i].id = i;
        //    infos[i].incomePeriod = 1.5f;
        //    infos[i].currentLevel = 0;
        //    infos[i].maxLevel = 5000;
        //    infos[i].costWeight = 1.08f;
        //    infos[i].valueWeight = 1.04f;
        //    infos[i].contents = "업그레이드시 매 {0}초 마다 {1}의 수입을 올려줍니다.";
        //}

        //infos[0].name = "동료1";
        //infos[1].name = "동료2";
        //infos[2].name = "동료3";

        //infos[0].costBase = 100;
        //infos[0].costCurrent = infos[0].costBase;
        //infos[1].costBase = 400;
        //infos[1].costCurrent = infos[1].costBase;
        //infos[2].costBase = 800;
        //infos[2].costCurrent = infos[2].costBase;

        //infos[0].valueBase = 1;
        //infos[0].valueCurrent = infos[0].valueBase;
        //infos[1].valueBase = 4;
        //infos[1].valueCurrent = infos[1].valueBase;
        //infos[2].valueBase = 8;
        //infos[2].valueCurrent = infos[2].valueBase;
    }

    public void GenerateJSON()
    {
        string data = JsonConvert.SerializeObject(infos);
        StreamWriter streamWriter = new StreamWriter(Application.dataPath + "/coworker.json");
        streamWriter.Write(data);
        streamWriter.Close();
        Debug.Log(Application.dataPath + "/coworker.json");
    }
    public void LoadJson()
    {
        string data = Resources.Load<TextAsset>("JsonFiles/coworker").text;
        infos = JsonConvert.DeserializeObject<CoworkerInfo[]>(data);
    }

	// Update is called once per frame
	void Update () {
		
	}
}

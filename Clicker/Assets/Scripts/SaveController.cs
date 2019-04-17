using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class SaveController : MonoBehaviour {

    [SerializeField]
    SaveData save;

	// Use this for initialization
	void Start () {
		
	}

    public void Save()
    {
        SaveData save = GameController.instance.GetSaveData();
        //string data = JsonConvert.SerializeObject(save);

        MemoryStream memoryStream = new MemoryStream();
        BinaryFormatter bf = new BinaryFormatter();

        bf.Serialize(memoryStream, save);
        string data = Convert.ToBase64String(memoryStream.GetBuffer());
        memoryStream.Close();

        PlayerPrefs.SetString("player", data);
        Debug.Log(data);
    }

    public void Load()
    {
        string data = PlayerPrefs.GetString("player");
        if (!string.IsNullOrEmpty(data))
        {
            Debug.Log(data);
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(data));
            BinaryFormatter bf = new BinaryFormatter();
            save = (SaveData)bf.Deserialize(memoryStream);
            //save = JsonConvert.DeserializeObject<SaveData>(data);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

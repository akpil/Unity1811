using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public static PlayerData instance;

    [SerializeField]
    private float value1;
    [SerializeField]
    private float value2;
    [SerializeField]
    private string value3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddValue1(float value)
    {
        value1 += value;
    }
    public void AddValue2(float value)
    {
        value2 += value;
    }
    public void SetValue3(string value)
    {
        value3 = value;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

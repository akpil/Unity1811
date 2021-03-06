﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController instance;

    [SerializeField]
    private SaveData userdata;

    private double maxValue;
    private double currentValue;
    private double gap;
    [SerializeField]
    private float levelValueWaight, levelBaseValue;
    private int levelCount;


    [SerializeField]
    private GemPool gemPool;
    private Gem currentGem;

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
    // Use this for initialization
    void Start () {
        userdata = new SaveData();
        userdata.money = 100;

        levelCount = 0;
        CalcMaxValue();
        currentValue = 0;
        gap = 5;
        float progress = (float)(currentValue / maxValue);
        UIController.instance.ShowGauge(progress);
        currentGem = gemPool.GetFromPool(Random.Range(0, 3));
    }

    private void CalcMaxValue()
    {
        maxValue = levelBaseValue * System.Math.Pow(levelValueWaight, levelCount);
    }

    public void Touch()
    {
        currentValue += gap;
        if (currentValue > maxValue)
        {
            levelCount++;
            CalcMaxValue();
            currentValue = 0;
            currentGem.HideGem();
            currentGem = gemPool.GetFromPool(Random.Range(0, 3));
        }
        float progress = (float)(currentValue / maxValue);
        UIController.instance.ShowGauge(progress);
        currentGem.SetProgress(progress);
    }

    public void AddMoney(double value)
    {
        userdata.money += value;

        //UI작업
    }

    public SaveData GetSaveData()
    {
        return userdata;
    }
}

[System.Serializable]
public class SaveData
{
    public double money;
    public int touchLevel;
}
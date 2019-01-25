using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController instance;
    private float maxValue;
    private float currentValue;
    private float gap;

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
        maxValue = 100;
        currentValue = 0;
        gap = 5;
        currentGem = gemPool.GetFromPool(Random.Range(0, 3));
    }

    public void Touch()
    {
        currentValue += gap;
        if (currentValue > maxValue)
        {
            currentValue = 0;
            currentGem.HideGem();
            currentGem = gemPool.GetFromPool(Random.Range(0, 3));
        }
        float progress = currentValue / maxValue;
        UIController.instance.ShowGauge(progress);
        currentGem.SetProgress(progress);
    }

	// Update is called once per frame
	void Update () {
		
	}
}

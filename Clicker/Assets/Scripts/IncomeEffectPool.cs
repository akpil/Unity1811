using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeEffectPool : MonoBehaviour {
    public static IncomeEffectPool instance;
    [SerializeField]
    private Transform canvas;
    [SerializeField]
    private IncomeEffect[] Prefabs;

    private List<IncomeEffect>[] Pool;

    private void Awake()
    {
        if (instance == null)
        {
            Pool = new List<IncomeEffect>[Prefabs.Length];
            for (int i = 0; i < Pool.Length; i++)
            {
                Pool[i] = new List<IncomeEffect>();
            }
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Use this for initialization
    void Start()
    {

    }

    public IncomeEffect GetFromPool(int index)
    {
        for (int i = 0; i < Pool[index].Count; i++)
        {
            if (!Pool[index][i].gameObject.activeInHierarchy)
            {
                Pool[index][i].gameObject.SetActive(true);
                return Pool[index][i];
            }
        }
        IncomeEffect temp = Instantiate(Prefabs[index], canvas);
        Pool[index].Add(temp);
        return temp;
    }
}

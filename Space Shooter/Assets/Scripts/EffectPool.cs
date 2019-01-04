using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eEffectType
{
    Asteroid,
    Enemy,
    Player
}

public class EffectPool : MonoBehaviour {
    public static EffectPool instance;

    public GameObject[] Prefab;
    private List<GameObject>[] Pool;
    private void Awake()
    {
        if (instance == null)
        {
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
        Pool = new List<GameObject>[Prefab.Length];
        for (int i = 0; i < Pool.Length; i++)
        {
            Pool[i] = new List<GameObject>();
        }
    }

    public GameObject GetFromPool(int id)
    {
        for (int i = 0; i < Pool[id].Count; i++)
        {
            if (!Pool[id][i].gameObject.activeInHierarchy)
            {
                Pool[id][i].gameObject.SetActive(true);
                return Pool[id][i];
            }
        }
        GameObject temp = Instantiate(Prefab[id]);
        Pool[id].Add(temp);
        return temp;
    }
}

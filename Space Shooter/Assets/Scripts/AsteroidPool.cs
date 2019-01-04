using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : MonoBehaviour {
    public AsteriodMovement[] Prefab;
    private List<AsteriodMovement>[] Pool;
    // Use this for initialization
    void Start()
    {
        Pool = new List<AsteriodMovement>[Prefab.Length];
        for (int i = 0; i < Pool.Length; i++)
        {
            Pool[i] = new List<AsteriodMovement>();
        }
    }

    public AsteriodMovement GetFromPool()
    {
        int id = Random.Range(0, Prefab.Length);
        for (int i = 0; i < Pool[id].Count; i++)
        {
            if (!Pool[id][i].gameObject.activeInHierarchy)
            {
                Pool[id][i].gameObject.SetActive(true);
                return Pool[id][i];
            }
        }
        AsteriodMovement temp = Instantiate(Prefab[id]);
        Pool[id].Add(temp);
        return temp;
    }
}

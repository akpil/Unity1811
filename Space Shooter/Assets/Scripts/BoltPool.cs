using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltPool : MonoBehaviour {

    public Bolt[] Prefab;
    private List<Bolt>[] Pool;
	// Use this for initialization
	void Start () {
        Pool = new List<Bolt>[Prefab.Length];
        for (int i = 0; i < Prefab.Length; i++)
        {
            Pool[i] = new List<Bolt>();
        }
	}

    public Bolt GetFromPool()
    {
        for (int i = 0; i < Pool[0].Count; i++)
        {
            if (!Pool[0][i].gameObject.activeInHierarchy)
            {
                Pool[0][i].gameObject.SetActive(true);
                return Pool[0][i];
            }
        }
        Bolt temp = Instantiate(Prefab[0]);
        Pool[0].Add(temp);
        return temp;
    }
    public Bolt GetFromPool(int index)
    {
        for (int i = 0; i < Pool[index].Count; i++)
        {
            if (!Pool[index][i].gameObject.activeInHierarchy)
            {
                Pool[index][i].gameObject.SetActive(true);
                return Pool[index][i];
            }
        }
        Bolt temp = Instantiate(Prefab[index]);
        Pool[index].Add(temp);
        return temp;
    }
}

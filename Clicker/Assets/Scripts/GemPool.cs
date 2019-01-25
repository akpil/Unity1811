using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPool : MonoBehaviour {

    [SerializeField]
    private Gem[] Prefabs;

    private List<Gem>[] Pool;

    private void Awake()
    {
        Pool = new List<Gem>[Prefabs.Length];
        for (int i = 0; i < Pool.Length; i++)
        {
            Pool[i] = new List<Gem>();
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    public Gem GetFromPool(int index)
    {
        for (int i = 0; i < Pool[index].Count; i++)
        {
            if (!Pool[index][i].gameObject.activeInHierarchy)
            {
                Pool[index][i].gameObject.SetActive(true);
                return Pool[index][i];
            }
        }
        Gem temp = Instantiate(Prefabs[index]);
        Pool[index].Add(temp);
        return temp;
    }
}

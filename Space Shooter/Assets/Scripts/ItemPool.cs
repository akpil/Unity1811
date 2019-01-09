using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour {

    public ItemMovement[] Prefab;
    private List<ItemMovement>[] Pool;
    // Use this for initialization
    void Start()
    {
        Pool = new List<ItemMovement>[Prefab.Length];
        for (int i = 0; i < Prefab.Length; i++)
        {
            Pool[i] = new List<ItemMovement>();
        }
    }
    public ItemMovement GetFromPool(int index)
    {
        for (int i = 0; i < Pool[index].Count; i++)
        {
            if (!Pool[index][i].gameObject.activeInHierarchy)
            {
                Pool[index][i].gameObject.SetActive(true);
                return Pool[index][i];
            }
        }
        ItemMovement temp = Instantiate(Prefab[index]);
        Pool[index].Add(temp);
        return temp;
    }
}

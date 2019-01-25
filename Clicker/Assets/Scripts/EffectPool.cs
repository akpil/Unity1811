using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eEffectType
{
    touch, phaseShift
}

public class EffectPool : MonoBehaviour {

    [SerializeField]
    private GameObject[] Prefabs;

    private List<GameObject>[] Pool;

    private void Awake()
    {
        Pool = new List<GameObject>[Prefabs.Length];
        for (int i = 0; i < Pool.Length; i++)
        {
            Pool[i] = new List<GameObject>();
        }
    }

    // Use this for initialization
    void Start () {
		
	}

    public GameObject GetFromPool(int index)
    {
        for (int i = 0; i < Pool[index].Count; i++)
        {
            if (!Pool[index][i].activeInHierarchy)
            {
                Pool[index][i].SetActive(true);
                return Pool[index][i];
            }
        }
        GameObject temp = Instantiate(Prefabs[index]);
        Pool[index].Add(temp);
        return temp;
    }
}

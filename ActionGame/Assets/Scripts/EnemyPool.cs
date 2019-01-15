using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {
    public static EnemyPool instance;

    [SerializeField]
    private EnemeyController[] enemyPrefab;
    [SerializeField]
    private EnemeyController a;
    private List<EnemeyController>[] pool;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            // 폴더에서 로드
            enemyPrefab = Resources.LoadAll<EnemeyController>("Prefab/Enemy");
            a = Resources.Load<EnemeyController>("Prefab/Enemy/MaleZombie");
            pool = new List<EnemeyController>[enemyPrefab.Length];
            for (int i = 0; i < pool.Length; i++)
            {
                pool[i] = new List<EnemeyController>();
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}

    public EnemeyController GetFromPool(int index)
    {
        for (int i = 0; i < pool[index].Count; i++)
        {
            if (!pool[index][i].gameObject.activeInHierarchy)
            {
                pool[index][i].gameObject.SetActive(true);
                return pool[index][i];
            }
        }
        EnemeyController newObj = Instantiate(enemyPrefab[index]);
        pool[index].Add(newObj);
        return newObj;
    }
}

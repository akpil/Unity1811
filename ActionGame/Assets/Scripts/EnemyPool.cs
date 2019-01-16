using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {
    public static EnemyPool instance;

    [SerializeField]
    private EnemyController[] enemyPrefab;
    [SerializeField]
    private EnemyController a;
    private List<EnemyController>[] pool;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            // 폴더에서 로드
            enemyPrefab = Resources.LoadAll<EnemyController>("Prefab/Enemy");
            a = Resources.Load<EnemyController>("Prefab/Enemy/MaleZombie");
            pool = new List<EnemyController>[enemyPrefab.Length];
            for (int i = 0; i < pool.Length; i++)
            {
                pool[i] = new List<EnemyController>();
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetIndexCount()
    {
        return enemyPrefab.Length;
    }

    // Use this for initialization
    void Start () {
		
	}

    public EnemyController GetFromPool(int index)
    {
        for (int i = 0; i < pool[index].Count; i++)
        {
            if (!pool[index][i].gameObject.activeInHierarchy)
            {
                pool[index][i].gameObject.SetActive(true);
                return pool[index][i];
            }
        }
        EnemyController newObj = Instantiate(enemyPrefab[index]);
        pool[index].Add(newObj);
        return newObj;
    }
}

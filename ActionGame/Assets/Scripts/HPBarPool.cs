using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarPool : MonoBehaviour {
    public static HPBarPool instance;
    [SerializeField]
    private Transform canvas;

    [SerializeField]
    private HPBar barPrefab;

    private List<HPBar> pool;
    // Use this for initialization
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            pool = new List<HPBar>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start () {
        
	}
    public HPBar GetFromPool()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].gameObject.activeInHierarchy)
            {
                pool[i].gameObject.SetActive(true);
                return pool[i];
            }
        }
        //HPBar newinst = Instantiate(barPrefab);
        //newinst.transform.SetParent(canvas);
        //newinst.transform.localScale = Vector3.one;
        HPBar newinst = Instantiate(barPrefab, canvas);
        pool.Add(newinst);
        return newinst;
    }
}

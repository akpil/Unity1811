using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    private Transform LSP, RSP;
    private int enemyIndexLength;
	// Use this for initialization
	void Start () {
        enemyIndexLength = EnemyPool.instance.GetIndexCount();
        StartCoroutine(Spawn());
	}

    private IEnumerator Spawn()
    {
        WaitForSeconds Gap = new WaitForSeconds(3);
        while(true)
        {
            int posRand = Random.Range(0, 2);
            int index = Random.Range(0, enemyIndexLength);
            EnemyController newEnemy = EnemyPool.instance.GetFromPool(index);
            if (posRand == 0)
            {
                newEnemy.transform.rotation = Quaternion.Euler(0, 0, 0);
                newEnemy.transform.position = LSP.position;
            }
            else
            {
                newEnemy.transform.rotation = Quaternion.Euler(0, 180, 0);
                newEnemy.transform.position = RSP.position;
            }
            newEnemy.StartMove();
            yield return Gap;
        }
    }


	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController instance;

    [SerializeField]
    private Transform LSP, RSP;
    private int enemyIndexLength;

    private float money;
    [SerializeField]
    private float income, incomeWeight;
    [SerializeField]
    private int increaseIncomeRate;
    private int spawnCount;

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
    void Start () {
        enemyIndexLength = EnemyPool.instance.GetIndexCount();
        StartCoroutine(Spawn());
        money = 0;
        spawnCount = 0;
        UIController.instance.ShowMoney(money);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }


    public void AddMoney(float amount)
    {
        money += amount;

        PlayerData.instance.AddValue2(3.77f);

        UIController.instance.ShowMoney(money);
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
            newEnemy.StartMove(income + incomeWeight * (spawnCount/increaseIncomeRate));
            spawnCount++;
            yield return Gap;
        }
    }


	// Update is called once per frame
	void Update () {
		
	}
}

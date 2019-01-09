using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {
    public static GameController instance;
    public UIController uIController;

    public AsteroidPool asteriodPool;
    public EnemyPool enemyPool;
    public ItemPool itemPool;
    public BGScroller[] BGs;

    private const float RELOAD_TIME = 5;
    private float currentReloadTime;

    private Coroutine routine;
    private int score;

    private GameObject playerObj;

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
        currentReloadTime = 0;
        score = 0;
        routine = StartCoroutine(SpawnRoutine());
        SoundController.instance.PlayeBGM(eBGMClips.BG01);
        playerObj = GameObject.FindGameObjectWithTag("Player");
        //GameObject[] BGObj = GameObject.FindGameObjectsWithTag("BG");
        //BGs = new BGScroller[BGObj.Length];
        //for (int i = 0; i < BGs.Length; i++)
        //{
        //    BGs[i] = BGObj[i].GetComponent<BGScroller>();
        //}
    }

    private IEnumerator SpawnRoutine()
    {
        WaitForSeconds pointThree = new WaitForSeconds(0.3f);
        WaitForSeconds reloadTime = new WaitForSeconds(RELOAD_TIME);
        int enemyCount = 2;
        int asteroidCount = 5;
        while (true)
        {
            if (enemyCount > 0 && asteroidCount > 0)
            {
                int currentRand = Random.Range(0, 2);
                if (currentRand == 0)
                {
                    AsteriodMovement newAst = asteriodPool.GetFromPool();
                    newAst.transform.position = new Vector3(Random.Range(-5f, 5f), 0, 16);
                    asteroidCount--;
                    yield return pointThree;
                }
                else
                {
                    EnemyController newEnemy = enemyPool.GetFromPool();
                    newEnemy.transform.position = new Vector3(Random.Range(-5f, 5f), 0, 16);
                    enemyCount--;
                    yield return pointThree;
                }
            }
            else if (enemyCount > 0)
            {
                EnemyController newEnemy = enemyPool.GetFromPool();
                newEnemy.transform.position = new Vector3(Random.Range(-5f, 5f), 0, 16);
                enemyCount--;
                yield return pointThree;
            }
            else
            {
                AsteriodMovement newAst = asteriodPool.GetFromPool();
                newAst.transform.position = new Vector3(Random.Range(-5f, 5f), 0, 16);
                asteroidCount--;
                yield return pointThree;
            }
            if (asteroidCount == 0 && enemyCount == 0)
            {
                ItemMovement newItem = itemPool.GetFromPool(Random.Range(0, 2));
                newItem.transform.position = new Vector3(Random.Range(-5f, 5f), 0, 16);
                enemyCount = 2;
                asteroidCount = 5;
                yield return reloadTime;
            }
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        // Print socre at UI
        uIController.ShowScore(score);
    }

    public void GameOver()
    {
        uIController.ShowGameStatus("Game Over");
        StopCoroutine(routine);
        for (int i = 0; i < BGs.Length; i++)
        {
            BGs[i].SetSpeed(0);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        //playerObj.SetActive(true);
        //uIController.ShowGameStatus("");
        //score = 0;
        //uIController.ShowScore(score);
        //for (int i = 0; i < BGs.Length; i++)
        //{
        //    BGs[i].SetSpeed(3);
        //}
        //routine = StartCoroutine(SpawnRoutine());
    }

    public void TestMethod(int a)
    {
        Debug.Log(a);
    }

	// Update is called once per frame
	void Update () {
        //if (currentReloadTime <= 0)
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        AsteriodMovement newAst = Instantiate(AsteriodPrefab);
        //        newAst.transform.position = new Vector3(Random.Range(-5, 5), 0, 16);
        //        //위치 배치 (x = -5 ~ 5/ z = 16)
        //    }
        //    Debug.Log(Time.time);
        //    currentReloadTime = RELOAD_TIME;
        //}
        //else
        //{
        //    currentReloadTime -= Time.deltaTime;
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (routine != null)
        //    {
        //        StopCoroutine(routine);
        //        routine = null;
        //    }
            
        //}

        //if(Input.GetKeyDown(KeyCode.Z))
        //{
        //    Debug.Log(routine != null);
        //}
        //gameObject.SetActive(false);
        ////~~~~~~~
        //gameObject.SetActive(true);
    }
    private void OnDisable()
    {
        routine = null;
    }
}

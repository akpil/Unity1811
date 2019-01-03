using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public AsteriodMovement[] AsteriodPrefab;
    public EnemyController enemyPrefab;

    private const float RELOAD_TIME = 5;
    private float currentReloadTime;

    private Coroutine routine;

	// Use this for initialization
	void Start () {
        currentReloadTime = 0;
        StartCoroutine(SpawnRoutine());
    }


    private IEnumerator SpawnRoutine()
    {
        WaitForSeconds pointThree = new WaitForSeconds(0.3f);
        WaitForSeconds reloadTime = new WaitForSeconds(RELOAD_TIME);
        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                AsteriodMovement newAst = Instantiate(AsteriodPrefab[Random.Range(0, AsteriodPrefab.Length)]);
                newAst.transform.position = new Vector3(Random.Range(-5f, 5f), 0, 16);
                yield return pointThree;

            }
            for (int i = 0; i < 2; i++)
            {
                EnemyController newEnemy = Instantiate(enemyPrefab);
                newEnemy.transform.position = new Vector3(Random.Range(-5f, 5f), 0, 16);
                yield return pointThree;
            }
            yield return reloadTime;
        }
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

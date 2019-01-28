using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    [SerializeField]
    protected float time;
    protected WaitForSeconds Waiting;

    protected void Awake()
    {
        Waiting = new WaitForSeconds(time);
    }

    protected void OnEnable()
    {
        StartCoroutine(Timeout());
    }

    protected IEnumerator Timeout()
    {
        yield return Waiting;
        gameObject.SetActive(false);
    }
}

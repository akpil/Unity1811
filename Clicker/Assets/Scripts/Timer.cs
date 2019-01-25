using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    [SerializeField]
    private float time;
    private WaitForSeconds Waiting;

    private void Awake()
    {
        Waiting = new WaitForSeconds(time);
    }

    private void OnEnable()
    {
        StartCoroutine(Timeout());
    }

    private IEnumerator Timeout()
    {
        yield return Waiting;
        gameObject.SetActive(false);
    }
}

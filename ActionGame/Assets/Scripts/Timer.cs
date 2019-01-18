using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    [SerializeField]
    private float TimeAmount;
	// Use this for initialization
	void OnEnable () {
        StartCoroutine(TimeOut());
	}
    private IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(TimeAmount);
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTimer : MonoBehaviour {

    public float Timer;
    private void OnEnable()
    {
        StartCoroutine(SleepAfter());
    }
    private IEnumerator SleepAfter()
    {
        yield return new WaitForSeconds(Timer);
        gameObject.SetActive(false);
    }
}

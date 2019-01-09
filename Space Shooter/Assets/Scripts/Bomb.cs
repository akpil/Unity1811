using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBolt"))
        {
            other.gameObject.SetActive(false);
        }
    }
}

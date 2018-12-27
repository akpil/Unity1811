using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private GameObject playerObj;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        offset = playerObj.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = playerObj.transform.position - offset;
	}
}

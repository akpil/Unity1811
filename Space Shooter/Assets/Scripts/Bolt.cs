﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour {
    private Rigidbody rb;
    public float Speed;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * Speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

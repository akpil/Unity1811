using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public int Speed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void Update () {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        //Debug.LogFormat("{0}\n{1}", hori.ToString(), vert.ToString());
        if (Input.GetButtonDown("Fire1"))
        {
            gameObject.SetActive(false);
        }
        rb.velocity = new Vector3(hori, 0, vert) * Speed;
	}
}

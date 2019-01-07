using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {
    private Rigidbody rb;
    public float Speed;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.back * Speed;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BGBumper"))
        {
            rb.position = new Vector3(rb.position.x, rb.position.y, rb.position.z + 40.94f);
        }
    }

    public void SetSpeed(float value)
    {
        Speed = value;
        rb.velocity = Vector3.back * Speed;
    }

    // Update is called once per frame
    void Update () {
		
	}
}

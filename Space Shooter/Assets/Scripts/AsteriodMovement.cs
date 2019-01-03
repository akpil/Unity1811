using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodMovement : MonoBehaviour {

    public float AngularSpeed;
    public float Speed;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.angularVelocity = Random.onUnitSphere * AngularSpeed;
        rb.velocity = Vector3.back * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBolt") || 
            other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                // game over
                Debug.Log("Game Over");
            }
            // add score
            Debug.Log("Add Score");
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

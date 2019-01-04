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
            GameController.instance.AddScore(1);
            other.gameObject.SetActive(false);
            GameObject effect = 
                EffectPool.instance.GetFromPool((int)eEffectType.Asteroid);
            effect.transform.position = transform.position;
            gameObject.SetActive(false);
        }
    }

    // Use this for initialization
    void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

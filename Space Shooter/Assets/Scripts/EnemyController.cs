using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Rigidbody rb;
    public float Speed;
    public BoltPool boltPool;
    public Transform boltFirePos;
	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
	}

    private void OnEnable()
    {
        StartCoroutine(autoFire());
        StartCoroutine(Evaid());
        rb.velocity = Vector3.back * Speed;
    }

    public void SetBoltPool(BoltPool p)
    {
        boltPool = p;
    }

    private IEnumerator Evaid()
    {
        WaitForSeconds pointEight = new WaitForSeconds(.8f);

        yield return pointEight;

        float EvaidSpeed = Random.Range(1.5f, 3f);
        if (rb.position.x > 0)
        {
            rb.velocity = new Vector3(-EvaidSpeed, 0, rb.velocity.z);
        }
        else
        {
            rb.velocity = new Vector3(EvaidSpeed, 0, rb.velocity.z);
        }

        yield return pointEight;

        rb.velocity = Vector3.back * Speed;

        yield return pointEight;

        if (rb.position.x > 0)
        {
            rb.velocity = new Vector3(-EvaidSpeed, 0, rb.velocity.z);
        }
        else
        {
            rb.velocity = new Vector3(EvaidSpeed, 0, rb.velocity.z);
        }

        yield return pointEight;

        rb.velocity = Vector3.back * Speed;
    }

    private IEnumerator autoFire()
    {
        yield return new WaitForSeconds(Random.Range(.8f, 1.2f));
        if (boltPool != null)
        {
            Bolt newBolt = boltPool.GetFromPool();
            newBolt.transform.position = boltFirePos.position;
            //newBolt.transform.rotation = boltFirePos.rotation;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBolt") ||
            other.gameObject.CompareTag("Player"))
        {
            GameController.instance.AddScore(1);
            other.gameObject.SetActive(false);
            GameObject effect =
                EffectPool.instance.GetFromPool((int)eEffectType.Enemy);
            effect.transform.position = transform.position;
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

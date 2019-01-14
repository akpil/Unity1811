using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyController : MonoBehaviour {
    private Animator anim;
    private Rigidbody2D rb2D;
    private float speed;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        speed = 2f;
    }

    private void OnEnable()
    {
        rb2D.velocity = transform.right * speed;
        anim.SetBool(AnimationHashList.isWalkHash, true);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FinishAttack()
    {
        anim.SetBool(AnimationHashList.isAttackHash, false);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Find player");
            anim.SetBool(AnimationHashList.isWalkHash, false);
            anim.SetBool(AnimationHashList.isAttackHash, true);
        }
    }
}

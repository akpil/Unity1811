using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eEnemyState
{
    Idle, FindPlayer, Attack, Dead
}

public class EnemyController : MonoBehaviour {
    private Animator anim;
    private Rigidbody2D rb2D;
    [SerializeField]
    private float speed;
    private PlayerController player;
    [SerializeField]
    private float MaxHP;
    private float currentHP;

    private int stateStep;
    private eEnemyState state;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void StartMove()
    {
        stateStep = 3;
        state = eEnemyState.Idle;
        currentHP = MaxHP;
        anim.SetBool(AnimationHashList.isWalkHash, false);
        anim.SetBool(AnimationHashList.isDeadHash, false);
        anim.SetBool(AnimationHashList.isAttackHash, false);
        StartCoroutine(EnemyState());
    }

    private IEnumerator EnemyState()
    {
        WaitForSeconds pointFive = new WaitForSeconds(.5f);
        while (true)
        {
            stateStep--;
            switch (state)
            {
                case eEnemyState.Idle:
                    if (stateStep <= 0)
                    {
                        state = eEnemyState.FindPlayer;
                        rb2D.velocity = transform.right * speed;
                        anim.SetBool(AnimationHashList.isWalkHash, true);
                        stateStep = 4;
                    }
                    break;
                case eEnemyState.FindPlayer:
                    if (stateStep <= 0)
                    {
                        state = eEnemyState.Idle;
                        rb2D.velocity = Vector3.zero;
                        anim.SetBool(AnimationHashList.isWalkHash, false);
                        stateStep = 3;
                    }
                    break;
                case eEnemyState.Attack:
                    if (stateStep <= 0)
                    {
                        anim.SetBool(AnimationHashList.isAttackHash, true);
                        stateStep = 2;
                    }
                    break;
                case eEnemyState.Dead:
                    if(stateStep <= 0)
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                default:
                    Debug.Log("enemy state error");
                    break;
            }
            yield return pointFive;
        }
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
        player.Hit(1);
    }

    public void Hit(float amount)
    {
        currentHP -= amount;
        Debug.Log("Enemy HP :" + currentHP.ToString());
        if (currentHP <= 0)
        {
            state = eEnemyState.Dead;
            anim.SetBool(AnimationHashList.isDeadHash, true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player == null)
            {
                player = collision.gameObject.GetComponent<PlayerController>();
            }
            player.Hit(1);
            state = eEnemyState.Attack;
            stateStep = 2;
            anim.SetBool(AnimationHashList.isWalkHash, false);
            anim.SetBool(AnimationHashList.isAttackHash, true);
        }
    }
}

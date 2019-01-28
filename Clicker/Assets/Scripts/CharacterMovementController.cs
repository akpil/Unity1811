using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour {
    private static readonly int moveHash = Animator.StringToHash("IsMove");
    [SerializeField]
    private Transform incomePos;
    [SerializeField]
    private Animator anim;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(movement());
        StartCoroutine(income());
	}

    private IEnumerator income()
    {
        int count = 0;
        WaitForSeconds pointFive = new WaitForSeconds(.5f);
        while (true)
        {
            count++;
            yield return pointFive;
            IncomeEffect income = IncomeEffectPool.instance.GetFromPool(0);
            income.transform.position = incomePos.position;
            income.SetText(count.ToString());
        }
    }

    private IEnumerator movement()
    {
        WaitForSeconds one = new WaitForSeconds(1);

        while (true)
        {
            if (Random.Range(0, 2) == 0) // right hand side move
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            rb.velocity = -transform.right * .5f;
            anim.SetBool(moveHash, true);
            yield return one;
            rb.velocity = Vector2.zero;
            anim.SetBool(moveHash, false);
            yield return one;

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

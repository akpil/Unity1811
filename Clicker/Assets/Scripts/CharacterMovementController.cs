using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour {
    [SerializeField]
    private int id;
    private static readonly int moveHash = Animator.StringToHash("IsMove");
    [SerializeField]
    private Transform incomePos;
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private float xMin, xMax;

    private Rigidbody2D rb;

    private Coroutine incomeRoutine;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(movement());
	}

    public void SetIncomePeriod(float period)
    {
        if (incomeRoutine != null)
        {
            StopCoroutine(incomeRoutine);
        }
        incomeRoutine = StartCoroutine(income(period));
    }

    private IEnumerator income(float period)
    {
        WaitForSeconds gap = new WaitForSeconds(period);
        while (true)
        {
            yield return gap;
            IncomeEffect incomeEffect = IncomeEffectPool.instance.GetFromPool(0);
            incomeEffect.transform.position = incomePos.position;
            string income = CoworkersController.instance.GetIncome(id);
            incomeEffect.SetText(income);
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
        rb.position = new Vector2(Mathf.Clamp(rb.position.x,
                                              xMin, xMax),
                                    rb.position.y);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {
    public BoltPool BossBoltPool;
    private int bossBoltID;
    public Transform BoltPos;

    private bool isInvinsible;

    private Rigidbody rb;
    public float speed;
    private Vector3 defaultPos;

    private PlayerController player;

    private Coroutine bossState;
    private Coroutine bossFireRoutine;

    public int maxHP;
    private int currentHP;

    private void Awake()
    {
        defaultPos = new Vector3(0, 0, 19.45f);
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        bossBoltID = 0;
        currentHP = maxHP;
        GameController.instance.ShowBossHP((float)currentHP / maxHP);
        isInvinsible = true;
        rb.position = defaultPos;
        bossState = StartCoroutine(BossState());
    }

    // Use this for initialization
    void Start () {
		
	}

    private IEnumerator BossState()
    {
        WaitForSeconds pointFive = new WaitForSeconds(.5f);
        WaitForSeconds two = new WaitForSeconds(2);

        rb.velocity = Vector3.back * speed;
        while (rb.position.z > 10.5f)
        {
            yield return pointFive;
        }
        rb.velocity = Vector3.zero;
        isInvinsible = false;

        rb.velocity = Vector3.right * speed;
        bossFireRoutine = StartCoroutine(BossFire());
        while (true)
        {
            yield return two;
            rb.velocity = Vector3.zero;
            StopCoroutine(bossFireRoutine);
            yield return pointFive;

            bossFireRoutine = StartCoroutine(BossFire());
            rb.velocity = Vector3.left * speed;
            yield return two;
            yield return two;
            rb.velocity = Vector3.zero;
            StopCoroutine(bossFireRoutine);
            yield return pointFive;

            bossFireRoutine = StartCoroutine(BossFire());
            rb.velocity = Vector3.right * speed;
            yield return two;
        }
    }

    private IEnumerator BossFire()
    {
        WaitForSeconds pointTwo = new WaitForSeconds(.2f);
        while (true)
        {
            Bolt newBolt = BossBoltPool.GetFromPool(bossBoltID);
            newBolt.transform.position = BoltPos.position;
            SoundController.instance.PlayerEffectSound(eEffectClips.WeaponEnemy);
            yield return pointTwo;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isInvinsible)
        {
            return;
        }
        if (other.gameObject.CompareTag("PlayerBolt") ||
            other.gameObject.CompareTag("Player"))
        {
            currentHP--;
            float hpPercent = (float)currentHP / maxHP;
            GameController.instance.ShowBossHP((float)currentHP / maxHP);
            if (currentHP <= 0)
            {
                GameController.instance.BossDead();
                GameController.instance.HideBossHP();
                gameObject.SetActive(false);
                //이펙트 사운드
            }
            else if (hpPercent < .3f)
            {
                bossBoltID = 1;
            }

            if (other.gameObject.CompareTag("Player"))
            {
                if (player == null)
                {
                    player = other.gameObject.GetComponent<PlayerController>();
                }
                player.Hit(1);
            }
            else
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}

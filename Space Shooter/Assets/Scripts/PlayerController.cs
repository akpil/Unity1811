using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public UIController uIController;

    public Bomb bomb;

    public BoltPool playerBoltPool;
    public Transform firePosition;
    public float ReloadTime;
    private float currentReloadTime;
    private int boltIndex;

    private Rigidbody rb;
    public float Speed;

    public float TiltAmount;

    public float xMax, xMin;
    public float zMax, zMin;

    public int MaxHP;
    private int currentHP;
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        currentReloadTime = 0;
        boltIndex = 0;
    }

    private void OnEnable()
    {
        currentHP = MaxHP;
        uIController.ShowHP(1);
    }

    // Update is called once per frame
    void Update () {
        float Hori = Input.GetAxis("Horizontal");
        float Vert = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(Hori, 0, Vert) * Speed;

        transform.rotation = Quaternion.Euler(0, 0, Hori * -TiltAmount);

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, xMin, xMax),
                                  0,
                                  Mathf.Clamp(rb.position.z, zMin, zMax));


        if(Input.GetButton("Fire1"))
        {
            if (currentReloadTime <= 0)
            {
                Bolt newBolt = playerBoltPool.GetFromPool(boltIndex);
                newBolt.transform.position = firePosition.position;
                SoundController.instance.PlayerEffectSound(eEffectClips.WeaponPlayer);
                currentReloadTime = ReloadTime;
            }            
        }
        currentReloadTime -= Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            bomb.gameObject.SetActive(true);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("EnemyBolt"))
        {
            Hit(1);
        }
    }
    private void OnDisable()
    {
        GameObject effect =
                EffectPool.instance.GetFromPool((int)eEffectType.Player);
        effect.transform.position = transform.position;
        GameController.instance.GameOver();
        SoundController.instance.PlayerEffectSound(eEffectClips.ExpPlayer);
    }
    public void Hit(int a)
    {
        currentHP--;
        Debug.Log(currentHP);
        if (currentHP <= 0)
        {
            gameObject.SetActive(false);
        }
        uIController.ShowHP((float)currentHP / MaxHP);
    }
    public void GetItem(eItemType type)
    {
        switch (type)
        {
            case eItemType.powerUP:
                boltIndex = 1;
                break;
            case eItemType.Life:
                if (currentHP < MaxHP)
                {
                    currentHP++;
                    uIController.ShowHP((float)currentHP / MaxHP);
                }
                break;
            default:
                Debug.Log("wrong item type");
                break;
        }
    }
}

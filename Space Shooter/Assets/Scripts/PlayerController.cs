using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public BoltPool playerBoltPool;
    public Transform firePosition;
    public float ReloadTime;
    private float currentReloadTime;

    private Rigidbody rb;
    public float Speed;

    public float TiltAmount;

    public float xMax, xMin;
    public float zMax, zMin;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        currentReloadTime = 0;

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
                Bolt newBolt = playerBoltPool.GetFromPool();
                newBolt.transform.position = firePosition.position;
                SoundController.instance.PlayerEffectSound(eEffectClips.WeaponPlayer);
                currentReloadTime = ReloadTime;
            }            
        }
        currentReloadTime -= Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("EnemyBolt"))
        {
            gameObject.SetActive(false);
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
}

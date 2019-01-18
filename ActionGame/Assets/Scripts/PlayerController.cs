using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator anim;

    private int HP;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        HP = 5;
    }

    public void Hit(int amount)
    {
        HP -= amount;
        UIController.instance.SubHP(amount);
    }

    // Update is called once per frame
    void Update () {
        float Horizontal = Input.GetAxis("Horizontal");

        if (Horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool(AnimationHashList.isAttackHash, true);
        }
    }

    public void AttackTarget(GameObject traget)
    {
        traget.SendMessage("Hit", 1);
    }
}

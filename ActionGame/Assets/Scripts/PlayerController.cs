using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool(AnimationHashList.isAttackHash, true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool(AnimationHashList.isAttackHash, false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool(AnimationHashList.isDeadHash, true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool(AnimationHashList.isDeadHash, false);
        }
    }
}

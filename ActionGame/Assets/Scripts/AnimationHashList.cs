using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHashList : MonoBehaviour {
    public static readonly int isAttackHash = Animator.StringToHash("IsAttack");
    public static readonly int isDeadHash = Animator.StringToHash("IsDead");
    public static readonly int isWalkHash = Animator.StringToHash("IsWalk");

}

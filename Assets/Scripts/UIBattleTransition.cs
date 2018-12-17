using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIBattleTransition : MonoBehaviour {

    Animator animator;
    void Start ()
    {
        animator = GetComponent<Animator>();
        GameManager.OnEnterBattle += TransitionIntoBattle;
	}

    void TransitionIntoBattle()
    {
        animator.SetTrigger("IntoBattle");
    }
}

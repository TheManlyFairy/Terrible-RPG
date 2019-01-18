using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    Character actor;
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        actor = GetComponent<Character>();
        actor.OnCombatActionPerformed += TriggerActionAnimation;
    }

    public void TriggerActionAnimation(ICombatAction actionInfo)
    {
        if(actionInfo is ScriptableSkill)
        {
            animator.SetTrigger((actionInfo as ScriptableSkill).animationTrigger);
        }
    }
}

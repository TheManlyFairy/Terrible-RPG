using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Utility;

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
        actor.OnTakeDamage += DamageAnimations;
        GameManager.OnEnterBattle += EnterBattleAnimation;
        GameManager.OnExitBattle += ExitBattleAnimatons;
    }

    public void TriggerActionAnimation(ICombatAction actionInfo)
    {
        if(actionInfo is ScriptableSkill)
        {
            AnimationTrigger actionTrigger = (actionInfo as ScriptableSkill).animationTrigger;
            //Debug.Log("Now triggering animation: " + Enum.GetName(actionTrigger.GetType(), actionTrigger));
            animator.SetTrigger(Enum.GetName(actionTrigger.GetType(), actionTrigger));
        }
    }
    public void TriggerWorldAnimations(Vector3 moveDirection)
    {
        //Debug.Log("Move Direction: " + moveDirection);
        if (moveDirection != Vector3.zero)
        {
            Vector3 lookDirection = Vector3.Normalize(moveDirection);
            animator.SetBool("Move", true);
            if (lookDirection != Vector3.zero)
                transform.forward = lookDirection;
        }
        else
        {
            animator.SetBool("Move",false);
        }

    }
    public void DamageAnimations()
    {
        //StartCoroutine(TakeDamage());
        if (actor.IsAlive)
            animator.SetTrigger("Damage");
        else
            animator.SetTrigger("Death");
    }
    public void EnterBattleAnimation()
    {
        if (actor is Player)
        {
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            animator.SetBool("Move", false);
        }
            
        else
            transform.localRotation = Quaternion.Euler(0,180,0);

        //Debug.Log("Triggering " + name);
        animator.SetTrigger("EnterBattle");
    }
    public void ExitBattleAnimatons()
    {
        animator.SetTrigger("ExitBattle");
    }

    IEnumerator TakeDamage()
    {
        yield return new WaitForSeconds(BattleManager.CurrentCharacter.Animator.GetCurrentAnimatorStateInfo(0).length);
        animator.SetTrigger("Damage");
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0).ToString());
        yield return new WaitForSeconds (animator.GetCurrentAnimatorStateInfo(0).length);
        if (actor.stats.HealthPercentage <= 0)
            animator.SetTrigger("Death");
    }
}

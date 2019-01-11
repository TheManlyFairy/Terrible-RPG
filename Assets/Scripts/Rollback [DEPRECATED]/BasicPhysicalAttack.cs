using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Character/Skills/General/Basic Physical Attack")]
public class BasicPhysicalAttack : Skill, ICombatAction
{
   public override void CombatAction(CharacterStats actor, CharacterStats target)
    {
        damageOutput = actor.strength - target.armor;

        if (damageOutput < 1)
            target.TakeDamage(1);
        else
            target.TakeDamage(damageOutput);
    }
}

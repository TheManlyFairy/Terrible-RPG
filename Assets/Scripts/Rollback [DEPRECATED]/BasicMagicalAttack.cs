using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Character/Skills/General/Basic Magical Attack")]
public class BasicMagicalAttack : Skill, ICombatAction
{
   public override void CombatAction(CharacterStats actor, CharacterStats target)
    {
        damageOutput = actor.magic - target.resistance;

        if (damageOutput < 1)
            target.TakeDamage(1);
        else
            target.TakeDamage(damageOutput);
    }
}

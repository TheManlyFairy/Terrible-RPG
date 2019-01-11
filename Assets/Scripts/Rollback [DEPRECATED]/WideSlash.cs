using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Character/Skills/Player/Wide Slash")]
public class WideSlash : Skill, ICombatAction
{
    public override void CombatAction(CharacterStats actor, List<CharacterStats> targets)
    {
        foreach(CharacterStats target in targets)
        {
            target.TakeDamage(actor.strength * damageBaseValue);
        }
    }
}

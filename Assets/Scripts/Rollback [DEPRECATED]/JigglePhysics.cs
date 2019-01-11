using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Character/Skills/Player/Jiggle Physics")]
public class JigglePhysics : Skill, ICombatAction
{
    public override void CombatAction(CharacterStats actor, CharacterStats target)
    {
        /*ScriptableStatus newEffect = (ArmorBuff)CreateInstance(typeof(ArmorBuff));
        newEffect.name = statusEffect.name;
        Debug.Log("Creating new " + newEffect.name + " of type " + newEffect.GetType());
        newEffect.InitializeEffect(target, actor.armor * statusBaseValue, statusEffect.duration);
        target.Actor.AddStatusEffect(newEffect);*/
    }
}


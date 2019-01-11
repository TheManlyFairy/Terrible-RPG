using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Character/Skills/Player/Methanol Spray")]
public class MethanolSpray : Skill, ICombatAction
{
    public override void CombatAction(CharacterStats actor, List<CharacterStats> targets)
    {
        foreach (CharacterStats target in targets)
        {
            damageOutput = actor.magic * damageBaseValue - target.TotalResistance;
            if (damageOutput < 1)
                target.TakeDamage(1);
            else
                target.TakeDamage(actor.magic * damageBaseValue);
            RollChanceForStatusEffect(target);
        }
    }

    void RollChanceForStatusEffect(CharacterStats target)
    {
        float chance = Random.Range(0f, 1f);
        if (chance <= statusChance)
        {
            /*ScriptableStatus newEffect = (BurnDebuff)CreateInstance(typeof(BurnDebuff));
            newEffect.name = statusEffect.name;
            //Debug.Log("Creating new " + newEffect.name + " of type " + newEffect.GetType());
            newEffect.InitializeEffect(target, statusBaseValue, statusEffect.duration);
            target.Actor.AddStatusEffect(newEffect);*/
        }
    }
}

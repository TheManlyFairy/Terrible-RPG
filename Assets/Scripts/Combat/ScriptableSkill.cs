using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

[CreateAssetMenu(menuName = "Combat/Skill")]
public class ScriptableSkill : ScriptableObject, ICombatAction
{
    public SkillType skillType;
    public SkillRange skillRange;
    public Sprite icon;
    public string skillName;
    public float manaCost;
    public float damageBaseMultiplier = 1;
    public ScriptableStatus statusEffect;

    [Range(0, 1)]
    public float statusChance;

    CharacterStats actor;
    CharacterStats target;
    float damageOutput;

    public virtual void CombatAction(CharacterStats actor, CharacterStats target)
    {
        this.actor = actor;
        this.target = target;

        if (skillType != SkillType.status)
            InflictDamage(skillType);

        if (statusEffect != null && UnityEngine.Random.Range(0f, 1f) <= statusChance)
            InflictStatus();
        //else
            //Debug.Log("Failed to afflict with status");
    }
    public virtual void CombatAction(CharacterStats actor, List<CharacterStats> targets)
    {
        this.actor = actor;
        foreach (CharacterStats target in targets)
        {
            this.target = target;
            //Debug.Log(target.name + " targeted");
            if (skillType != SkillType.status)
            {
                //Debug.Log(target.name + " damaged");
                InflictDamage(skillType);
            }
                

            if (statusEffect != null && UnityEngine.Random.Range(0f, 1f) <= statusChance)
            {
                //Debug.Log(target.name + " afflicted");
                InflictStatus();
            }
                
        }
    }

    void InflictDamage(SkillType damageType)
    {
        if (skillType == SkillType.physical)
        {
            damageOutput = actor.TotalStrength * damageBaseMultiplier - target.TotalArmor;
            target.TakeDamage(damageOutput);
        }
        else if (skillType == SkillType.magical)
        {
            damageOutput = actor.TotalMagic * damageBaseMultiplier - target.TotalResistance;
            target.TakeDamage(damageOutput);
        }
    }
    void InflictStatus()
    {
        if (!target.Actor.ContainsStatus(statusEffect))
        {
            //ScriptableStatus newEffect = (ScriptableStatus)CreateInstance(typeof(ScriptableStatus));
            ScriptableStatus newEffect = Instantiate(statusEffect) as ScriptableStatus;
            //newEffect.name = statusEffect.name;
            //Debug.Log("Creating new " + newEffect.name + " of type " + newEffect.statusType);
            target.Actor.AddStatusEffect(newEffect);
            newEffect.InitializeEffect(actor, target);
        }
        else
            Debug.Log(target.Actor.name + " already afflicted with this");
    }
}

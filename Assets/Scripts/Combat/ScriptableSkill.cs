using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

[CreateAssetMenu(menuName = "Combat/Skill")]
public class ScriptableSkill : ScriptableObject, ICombatAction
{
    [Tooltip("What is the nature of this skill. This changes the stats this skill uses for calculations.")]
    public SkillType skillType;
    [Tooltip("Is this a single targeted ro multi targeted skill.")]
    public SkillRange skillRange;
    [Tooltip("Can this skill target player characters, enemy characters or both.")]
    public SkillTargeting skillTargeting;
    [Tooltip("What type of character animation should be used with this skill.")]
    public AnimationTrigger animationTrigger;
    public Sprite icon;
    public AudioClip soundEffect;
    public string skillName;
    [SerializeField]
    int levelRequirement;
    public float manaCost;
    public float damageBaseMultiplier = 1;
    public ScriptableStatus statusEffect;

    [Range(0, 1)]
    public float statusChance;

    public Character Actor
    {
        set { actor = value; }
        get { return actor; }
    }
    Character actor;
    Character target;
    float damageOutput;
   

    public bool IsUnlocked { get { return (actor as Player).level > levelRequirement; } }

    public virtual void CombatAction(Character target)
    {
        this.target = target;
        if (skillType != SkillType.status)
            InflictDamage(skillType);

        if (statusEffect != null && UnityEngine.Random.Range(0f, 1f) <= statusChance)
            InflictStatus();
    }
    public virtual void CombatAction(List<Character> targets)
    {
        //this.actor = actor;
        foreach (Character target in targets)
        {
            this.target = target;
            if (skillType != SkillType.status)
            {
                InflictDamage(skillType);
            }

            if (statusEffect != null && UnityEngine.Random.Range(0f, 1f) <= statusChance)
            {
                InflictStatus();
            }
        }
    }

    void InflictDamage(SkillType damageType)
    {
        if (skillType == SkillType.physical)
        {
            Debug.Log(actor.name + " targeted ");
            damageOutput = actor.stats.TotalStrength * damageBaseMultiplier - target.stats.TotalArmor;
            target.TakeDamage(damageOutput);
        }
        else if (skillType == SkillType.magical)
        {
            Debug.Log(actor.name + " targeted " + target.name);
            damageOutput = actor.stats.TotalMagic * damageBaseMultiplier - target.stats.TotalResistance;
            target.TakeDamage(damageOutput);
        }
    }
    void InflictStatus()
    {
        if (!target.ContainsStatus(statusEffect))
        {
            //ScriptableStatus newEffect = (ScriptableStatus)CreateInstance(typeof(ScriptableStatus));
            ScriptableStatus newEffect = Instantiate(statusEffect) as ScriptableStatus;
            //newEffect.name = statusEffect.name;
            //Debug.Log("Creating new " + newEffect.name + " of type " + newEffect.statusType);
            target.AddStatusEffect(newEffect);
            newEffect.InitializeEffect(actor.stats, target.stats);
        }
        else
        {

        }
    }
}

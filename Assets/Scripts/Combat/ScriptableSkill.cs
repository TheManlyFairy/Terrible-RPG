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

    public int RequiredLevel { get { return levelRequirement; } }

    Character actor;
    Character target;
    float damageOutput;
   

    
    public virtual void CombatAction(Character actor, Character target)
    {
        this.actor = actor;
        this.target = target;
        if (skillType != SkillType.status)
            InflictDamage(skillType);

        if (statusEffect != null && UnityEngine.Random.Range(0f, 1f) <= statusChance)
        {
            Debug.LogWarning("Inflicting status on " + target.name);
            InflictStatus();
        }
            
    }
    public virtual void CombatAction(Character actor, List<Character> targets)
    {
        this.actor = actor;
        int counter = 1;
        foreach (Character target in targets)
        {
            //Debug.LogWarning("Counter: " + counter);
            counter++;
            this.target = target;
            //Debug.Log("Target is " + target);

            float rolledStatusChance = UnityEngine.Random.Range(0f, 1f);
            //Debug.LogWarning("statusEffect != null: " + (statusEffect != null));
            //Debug.LogWarning("rolledStatusChance <= statusChance: " + (rolledStatusChance <= statusChance));

            if (skillType != SkillType.status)
                InflictDamage(skillType);

            if (statusEffect != null && rolledStatusChance <= statusChance)
                InflictStatus();
        }
    }

    void InflictDamage(SkillType damageType)
    {
        if (skillType == SkillType.physical)
        {
            //Debug.Log(name +" used by " +actor.name + " targeted ");
            damageOutput = actor.stats.TotalStrength * damageBaseMultiplier - target.stats.TotalArmor;
            target.TakeDamage(damageOutput);
        }
        else if (skillType == SkillType.magical)
        {
            //Debug.Log(actor.name + " targeted " + target.name);
            damageOutput = actor.stats.TotalMagic * damageBaseMultiplier - target.stats.TotalResistance;
            target.TakeDamage(damageOutput);
        }
    }
    void InflictStatus()
    {
        //Debug.LogWarning("Inflicting Status");
        if (!target.ContainsStatus(statusEffect))
        {
            ScriptableStatus newEffect = Instantiate(statusEffect) as ScriptableStatus;
            newEffect.InitializeEffect(actor.stats, target.stats);
            target.AddStatusEffect(newEffect);
        }
    }
}

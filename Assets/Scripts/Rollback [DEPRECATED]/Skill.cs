using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public abstract class Skill : ScriptableObject, ICombatAction
{

    public SkillType skillType;
    public SkillRange skillRange;
    public Sprite icon;
    public string skillName;
    public float manaCost;
    public float damageBaseValue;
    public float statusBaseValue;
    public ScriptableStatus statusEffect;

    [Range(0, 1)]
    public float statusChance;

    protected float damageOutput;

    public virtual void CombatAction(CharacterStats actor, CharacterStats target)
    {
        throw new NotImplementedException();
    }
    public virtual void CombatAction(CharacterStats actor, List<CharacterStats> targets)
    {
        throw new NotImplementedException();
    }
}

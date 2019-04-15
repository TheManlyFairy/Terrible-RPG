using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : Character, IComparable<Enemy>
{
    [SerializeField]
    int expValue;
    [SerializeField]
    [Range(0f,1f)]
    float skillUseChance;
    public int ExpValue { get { return expValue; } }

    public void CreateStatsAsInstance()
    {
        //Debug.Log("Instancing character stats for " + name);
        CharacterStats statInstance = Instantiate(stats);
        stats = statInstance;
        stats.Actor = this;
    }

    public void RollChanceForSkillUse()
    {
        if(skills.Count > 0)
        {
            float chance = UnityEngine.Random.Range(0f, 1f);
            if (chance < skillUseChance)
            {
                combatAction = skills[(UnityEngine.Random.Range(0, skills.Count))];
                if (stats.currentMana < (combatAction as ScriptableSkill).manaCost)
                    combatAction = basicAttack;
            }
        }
        else
            combatAction = basicAttack;
    }
    public int CompareTo(Enemy other)
    {
        throw new NotImplementedException();
    }
}
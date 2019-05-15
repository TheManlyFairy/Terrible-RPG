using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : Character, IComparable<Player>
{
    public ScriptableEquipment[] characterEquipment;
    
    public int currentExp = 0;
    public int expToNextLevel;


    void Start()
    {
        //animator = GetComponent<Animator>();
        //afflictedStatuses = new List<ScriptableStatus>();
        //stats.Actor = this;
        //stats.ResetStats();
        //SetupAsActorForSkills();
        ApplyAllGearBonuses();
        expToNextLevel = (int)Math.Pow(level, 1.75) + 50;
    }

    public void ApplyAllGearBonuses()
    {
        for (int i = 0; i < characterEquipment.Length; i++)
        {
            if (characterEquipment[i])
                stats.Equip(characterEquipment[i]);
        }
    }
    public void GainExp(int expGained)
    {
        currentExp += expGained;
        while (currentExp > expToNextLevel)
        {
            level++;
            currentExp -= expToNextLevel;
            expToNextLevel = (int)Math.Pow(level, 1.75) + 50;
        }
    }
    public int CompareTo(Player other)
    {
        throw new NotImplementedException();
    }


}
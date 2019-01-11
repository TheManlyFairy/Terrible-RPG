using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character : MonoBehaviour, IComparable<Character> {

    public CharacterStats stats;
    public ScriptableSkill basicAttack;
    public List<ScriptableSkill> skills;
    public ICombatAction combatAction;
    public List<ScriptableStatus> afflictedStatuses;

    [SerializeField]
    Character target;

    void Start()
    {
        afflictedStatuses = new List<ScriptableStatus>();
        stats.Actor = this;
        stats.ResetStats();
    }
    
    public void Attack(Character target)
    {
        Debug.Log(name + " used " + basicAttack.name + " on " + target.name);
        basicAttack.CombatAction(stats, target.stats);
    }

    public void CountdownStatuses()
    {
        foreach(ScriptableStatus status in afflictedStatuses)
        {
            status.PerTurnEffect();
            Debug.Log(name + " counting down "+status.name +" to "+status.Countdown);
            
        }
        afflictedStatuses = afflictedStatuses.Where(status => status.Countdown > 0).ToList();
    }
    public void AddStatusEffect(ScriptableStatus status)
    {
        Debug.Log("Adding status for " + name);
        if(ContainsStatus(status))
        {
            Debug.Log(name+ " already afflicted");
            ScriptableStatus foundStatus = afflictedStatuses.Find(afflictedStatus => status.statusType == afflictedStatus.statusType);
            //foundStatus.RefreshDuration();
            //Debug.Log(name + "'s " + foundStatus.name + " effect has been refreshed to " + foundStatus.Countdown);
        }
        else
        {
            Debug.Log(name + " has received the " + status.effectName + " effect");
            afflictedStatuses.Add(status);
        }
    }
    public bool ContainsStatus(ScriptableStatus status)
    {
        /*foreach (ScriptableStatus afflictedStatus in afflictedStatuses)
        {
            if (afflictedStatus.statusType == status.statusType)
            {
                return true;
            }
        }
        return false;*/

        ScriptableStatus foundStatus = afflictedStatuses.Find(afflictedStatus => status.effectName == afflictedStatus.effectName);
        return foundStatus != null ? true : false;
    }

    public int CompareTo(Character other)
    {
        throw new NotImplementedException();
    }
}


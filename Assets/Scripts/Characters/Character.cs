using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character : MonoBehaviour, IComparable<Character>
{
    Animator animator;

    public CharacterStats stats;
    public ScriptableSkill basicAttack;
    public List<ScriptableSkill> skills;
    public ICombatAction combatAction;
    public List<ScriptableStatus> afflictedStatuses;
    public Character target;
    public delegate void OnCombatAction(ICombatAction actionInfo);
    public event OnCombatAction OnCombatActionPerformed;

    public Action<float> OnHealthChange;
    public Action<float> OnManaChange;
    public Action OnTakeDamage;
    
    public Animator Animator { get { return animator; } }
    public bool IsAlive { get { return stats.currentHealth > 0; } }
    void Awake()
    {
        animator = GetComponent<Animator>();
        afflictedStatuses = new List<ScriptableStatus>();
        stats.Actor = this;
        stats.ResetStats();
    }

    public void CountdownStatuses()
    {
        foreach (ScriptableStatus status in afflictedStatuses)
        {
            Debug.Log(name + " counting down " + status.name + " to " + status.Countdown);
            status.PerTurnEffect();
        }
        afflictedStatuses = afflictedStatuses.Where(status => status.Countdown > 0).ToList();
    }
    public void AddStatusEffect(ScriptableStatus status)
    {
        Debug.Log("Adding status for " + name);
        if (ContainsStatus(status))
        {
            Debug.Log(name + " already afflicted");
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
    public void RemoveStatus(ScriptableStatus status)
    {
        afflictedStatuses.Remove(status);
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
        //return afflictedStatuses.Contains(status);

        ScriptableStatus foundStatus = afflictedStatuses.Find(afflictedStatus => status.effectName == afflictedStatus.effectName);
        return foundStatus != null ? true : false;
    }
    public void PerformAction()
    {
        //Debug.Log(name+" acting vs "+this.target)
        combatAction.CombatAction(this, target);
        if (OnCombatActionPerformed != null)
            OnCombatActionPerformed(combatAction);
    }
    public void PerformAction(List<Character> enemies)
    {
        combatAction.CombatAction(this, enemies);
        if (OnCombatActionPerformed != null)
            OnCombatActionPerformed(combatAction);
    }
    public void TakeDamage(float damage)
    {
        stats.TakeDamage(damage);

        if (OnHealthChange != null)
            OnHealthChange(stats.HealthPercentage);
        if (OnTakeDamage != null)
            OnTakeDamage();

        Debug.Log(name + " took " + damage + " damage!");
    }
    public void ReduceMana(float manaLoss)
    {
        stats.ReduceMana(manaLoss);

        if (OnManaChange != null)
            OnManaChange(stats.ManaPercentage);
    }
    public void Heal(float healing)
    {
        Debug.Log("Healing " + name + " for " + healing);
        stats.Heal(healing);
    }

    public int CompareTo(Character other)
    {
        throw new NotImplementedException();
    }
    /*public void Attack(Character target)
   {
       Debug.Log(name + " used " + basicAttack.name + " on " + target.name);
       basicAttack.CombatAction(stats, target.stats);
   }*/
}


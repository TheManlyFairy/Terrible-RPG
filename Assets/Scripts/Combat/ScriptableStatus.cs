using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

[CreateAssetMenu(menuName = "Combat/Status Effect")]
public class ScriptableStatus : ScriptableObject//, IEquatable<ScriptableStatus>
{
    public StatusType statusType;
    public AffectedStat actorStat;
    public AffectedStat targetStat;
    public string effectName;
    public int duration;
    public float instantEffectMultiplier;
    public float perTurnEffectMultiplier;

    CharacterStats affectedTarget;
    float instantEffectBaseValue;
    float perTurnEffectBaseValue;

    int countdown;

    public int Countdown { get { return countdown; } }
    public bool IsOver { get { return countdown <= 0 ? true : false; } }

    public virtual void InitializeEffect(CharacterStats actor, CharacterStats target)
    {
        countdown = duration;
        affectedTarget = target;

        //Debug.Log("Intiliazing against " + target.name);
        // Debug.Log("Effect is of type " + statusType);
        switch (statusType)
        {
            case StatusType.heal:
                instantEffectBaseValue = actor.TotalMagic;
                target.Heal(instantEffectBaseValue * instantEffectMultiplier);
                EffectEnd();
                break;
            case StatusType.burn:
                instantEffectBaseValue = target.TotalArmor;
                perTurnEffectBaseValue = actor.TotalMagic;
                //target.BonusArmor -= (instantEffectBaseValue * instantEffectMultiplier);
                //Debug.Log("Lowered " + target.name + "'s armor by " + (baseValue * instantEffectMultiplier));
                DebuffStat();
                break;
            case StatusType.poison:
                instantEffectBaseValue = target.TotalResistance;
                perTurnEffectBaseValue = target.TotalHealth;
                DebuffStat();
                break;
            case StatusType.buff:
                SetBuffBaseValueFromActor(actor);
                BuffStat();
                break;
            case StatusType.debuff:
                SetDebuffDebuffBaseValueFromActor();
                DebuffStat();
                break;
        }

    }
    public virtual void PerTurnEffect()
    {
        if (statusType == StatusType.burn)
        {
            affectedTarget.TakeDamage(perTurnEffectBaseValue * perTurnEffectMultiplier);
        }
        else if (statusType == StatusType.poison)
        {
            affectedTarget.TakeDamage(perTurnEffectBaseValue * perTurnEffectMultiplier);
        }

        Tick();
    }
    public virtual void EffectEnd()
    {
        switch (statusType)
        {
            case StatusType.buff:
                DebuffStat();
                break;
            case StatusType.debuff:
                BuffStat();
                break;
        }
    }

    public void Tick()
    {
        countdown -= 1;
        if (countdown <= 0)
            EffectEnd();
    }
    public void RefreshDuration()
    {
        countdown = duration;
    }

    void SetBuffBaseValueFromActor(CharacterStats actor)
    {
        switch (actorStat)
        {
            case AffectedStat.strength: instantEffectBaseValue = actor.TotalStrength; break;
            case AffectedStat.armor: instantEffectBaseValue = actor.TotalArmor; break;
            case AffectedStat.magic: instantEffectBaseValue = actor.TotalMagic; break;
            case AffectedStat.resistance: instantEffectBaseValue = actor.TotalResistance; break;
            case AffectedStat.agility: instantEffectBaseValue = actor.TotalAgility; break;
        }
        //Debug.Log("Set buff value to " + instantEffectBaseValue + " from " + actor.Actor.name + "'s " + actorStat);
    }
    void SetDebuffDebuffBaseValueFromActor()
    {
        switch (targetStat)
        {
            case AffectedStat.strength: instantEffectBaseValue = affectedTarget.TotalStrength; break;
            case AffectedStat.armor: instantEffectBaseValue = affectedTarget.TotalArmor; break;
            case AffectedStat.magic: instantEffectBaseValue = affectedTarget.TotalMagic; break;
            case AffectedStat.resistance: instantEffectBaseValue = affectedTarget.TotalResistance; break;
            case AffectedStat.agility: instantEffectBaseValue = affectedTarget.TotalAgility; break;
        }
        //Debug.Log("Set debuff value to " + instantEffectBaseValue + " from " + affectedTarget.Actor.name + "'s " + targetStat);
    }

    void BuffStat()
    {
        switch (targetStat)
        {
            case AffectedStat.strength: affectedTarget.BonusStrength += (instantEffectBaseValue * instantEffectMultiplier); break;
            case AffectedStat.armor: affectedTarget.BonusArmor += (instantEffectBaseValue * instantEffectMultiplier); break;
            case AffectedStat.magic: affectedTarget.BonusMagic += (instantEffectBaseValue * instantEffectMultiplier); break;
            case AffectedStat.resistance: affectedTarget.BonusResistance += (instantEffectBaseValue * instantEffectMultiplier); break;
            case AffectedStat.agility: affectedTarget.BonusAgility += (instantEffectBaseValue * instantEffectMultiplier); break;
        }
        Debug.Log("Buffed " + affectedTarget.Actor.name + "'s " + targetStat + " by " + (instantEffectBaseValue * instantEffectMultiplier));
    }
    void DebuffStat()
    {
        switch (targetStat)
        {
            case AffectedStat.strength: affectedTarget.BonusStrength -= (instantEffectBaseValue * instantEffectMultiplier); break;
            case AffectedStat.armor: affectedTarget.BonusArmor -= (instantEffectBaseValue * instantEffectMultiplier); break;
            case AffectedStat.magic: affectedTarget.BonusMagic -= (instantEffectBaseValue * instantEffectMultiplier); break;
            case AffectedStat.resistance: affectedTarget.BonusResistance -= (instantEffectBaseValue * instantEffectMultiplier); break;
            case AffectedStat.agility: affectedTarget.BonusAgility -= (instantEffectBaseValue * instantEffectMultiplier); break;
        }
        Debug.Log("Debuffed " + affectedTarget.Actor.name + "'s " + targetStat+" by "+(instantEffectBaseValue * instantEffectMultiplier));
    }
    /*public bool Equals(ScriptableStatus other)
    {
        ScriptableStatus status = other as ScriptableStatus;
        return other != null && status.GetType() == this.GetType() ? true : false;
    }*/
}

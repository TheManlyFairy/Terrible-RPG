using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Character/Stats")]
public class CharacterStats : ScriptableObject
{
    public static int partyLevel = 1;

    Character actor;
    public Character Actor
    {
        set { actor = value; }
        get { return actor; }
    }
    public string characterName;
    #region Base Stats Per Level (Public Variables)
    // the base value of every character. These values do not change
    public float maxHealth, currentHealth;
    public float maxMana, currentMana;
    public float strength;
    public float armor;
    public float magic;
    public float resistance;
    public float agility;
    public float statusResistance;
    #endregion
    #region Real Time Base Stats
    //the actual stats represnted by level growth
    public float BaseHealth { get { return maxHealth * partyLevel; } }
    public float BaseMana { get { return maxMana*partyLevel; } }
    public float BaseStrength { get { return strength*partyLevel; } }
    public float BaseArmor { get { return armor*partyLevel; } }
    public float BaseMagic { get { return magic*partyLevel; } }
    public float BaseResistance { get { return resistance * partyLevel; } }
    public float BaseAgility { get { return agility*partyLevel; } }
    #endregion
    #region Bonus Stats (Private Variables)
    //bonus stats are only modified in combat and are reset to 0 at every battle end
    float bonusHealth;
    float bonusMana;
    float bonusStrength;
    float bonusArmor;
    float bonusMagic;
    float bonusResistance;
    float bonusAgility;
    float bonusStatusResistance;
    #endregion
    #region Bonus Stats Properties
    public float BonusHealth { set { bonusHealth = value; } get { return bonusHealth; } }
    public float BonusMana { set { bonusMana = value; } get { return bonusMana; } }
    public float BonusStrength { set { bonusStrength = value; } get { return bonusStrength; } }
    public float BonusArmor { set { bonusArmor = value; } get { return bonusArmor; } }
    public float BonusMagic { set { bonusMagic = value; } get { return bonusMagic; } }
    public float BonusResistance { set { bonusResistance = value; } get { return bonusResistance; } }
    public float BonusAgility { set { bonusAgility = value; } get { return bonusAgility; } }
    #endregion
    #region Total Stat Properties
    // The stat total of a character, calculated through base values * character level + bonus stats
    public float TotalHealth { get { return BaseHealth + BonusHealth; } }
    public float TotalMana { get { return BaseMana + BonusMana; } }
    public float TotalStrength { get { return BaseStrength + BonusStrength; } }
    public float TotalArmor { get { return BaseArmor + BonusArmor; } }
    public float TotalMagic { get { return BaseMagic + BonusMagic; } }
    public float TotalResistance { get { return BaseResistance + BonusResistance; } }
    public float TotalAgility { get { return BaseAgility + BonusAgility; } }
    #endregion

    public float HealthPercentage { get { return currentHealth / TotalHealth; } }
    public float ManaPercentage { get { return currentMana / TotalMana; } }
   
    public void Equip(ScriptableEquipment gearPiece)
    {
        BonusHealth += gearPiece.bonusHealth;
        BonusMana += gearPiece.bonusMana;
        BonusStrength += gearPiece.bonusStrength;
        BonusArmor += gearPiece.bonusArmor;
        BonusMagic += gearPiece.bonusMagic;
        BonusResistance += gearPiece.bonusResistance;
        BonusAgility += gearPiece.bonusAgility;
    }
    public void Unequip(ScriptableEquipment gearPiece)
    {
        BonusHealth -= gearPiece.bonusHealth;
        BonusMana -= gearPiece.bonusMana;
        BonusStrength -= gearPiece.bonusStrength;
        BonusArmor -= gearPiece.bonusArmor;
        BonusMagic -= gearPiece.bonusMagic;
        BonusResistance -= gearPiece.bonusResistance;
        BonusAgility -= gearPiece.bonusAgility;
    }

    public void ResetStats()
    {
        currentHealth = TotalHealth;
        currentMana = TotalMana;
        bonusHealth = 0;
        bonusMana = 0;
        bonusStrength = 0;
        bonusArmor = 0;
        bonusMagic = 0;
        bonusResistance = 0;
        bonusAgility = 0;
    }
    public void TakeDamage(float damage)
    {
        if (damage < 1)
            currentHealth -= 1;
        else
            currentHealth -= damage;
        //Debug.Log(actor.name + " took " + damage + " damage!");
    }
    public void ReduceMana(float manaLoss)
    {
        currentMana -= manaLoss;
    }
    public void Heal(float healing)
    {
        currentHealth += healing;
        if (currentHealth >= TotalHealth)
            currentHealth = TotalHealth;
    }
    public void Clarity(float manaRestored)
    {
        currentMana += manaRestored;
        if (currentMana >= TotalMana)
            currentMana = TotalMana;
    }
}

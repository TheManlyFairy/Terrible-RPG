using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Stats")]
public class CharacterStats : ScriptableObject
{
    public string characterName;
    public float maxHealth;
    public float health;
    public float mana;
    public float strength;
    public float defense;
    public float intelligence;
    public float agility;

    public void Reset()
    {
        health = maxHealth;
    }
    public float TakeDamage(CharacterStats attacker)
    {
        return health -= (attacker.strength - defense);
    }

    public override string ToString()
    {
        return "Name: " + characterName + "\nMax Health: " + maxHealth + "\nMana: " + mana + "\nStrenth: " + strength 
            + "\nDefence: " + defense + "\nIntelligence: " + intelligence + "\nAgility: " + agility;
    }
}
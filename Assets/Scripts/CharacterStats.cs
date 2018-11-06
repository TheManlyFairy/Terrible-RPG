using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Stats")]
public abstract class CharacterStats : ScriptableObject
{
    public float health;
    public float mana;
    public float strength;
    public float intelligence;
    public float agility;
}

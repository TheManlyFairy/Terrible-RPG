using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IComparable<Character> {

    public CharacterStats stats;
    public List<Skill> skills;

    public int CompareTo(Character other)
    {
        throw new NotImplementedException();
    }
}

class CompareCharactersByAgi : IComparer<Character>
{
    // Characters with higher Agility stat will have higher priority in the battle order
    public int Compare(Character x, Character y)
    {
        return (int)(y.stats.agility) - (int)x.stats.agility;
    }
}

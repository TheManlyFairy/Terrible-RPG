using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuxiliaryClasses
{}

public class CompareCharactersByAgi : IComparer<Character>
{
    // Characters with higher Agility stat will have higher priority in the battle order
    public int Compare(Character x, Character y)
    {
        return (int)(y.stats.agility) - (int)x.stats.agility;
    }
}

public class ComparePlayersByAgi : IComparer<Player>
{
    public new int Compare(Player x, Player y)
    {
        return (int)(y.stats.agility) - (int)x.stats.agility;
    }
}

public class CompareEnemiesByAgi : IComparer<Enemy>
{
    public new int Compare(Enemy x, Enemy y)
    {
        return (int)(y.stats.agility) - (int)x.stats.agility;
    }
}
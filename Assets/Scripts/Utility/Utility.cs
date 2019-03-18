using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    //is the game currently in battle mode or in world mode
    public enum GameState { world, battle };
    //used to define what stats are used in the skill calculations
    public enum SkillType { physical, magical, status }
    //defines what characters can be targeted by this skill in combat
    public enum SkillTargeting { playerOnly, enemyOnly, allTargets }
    //defines whether the skill targets a single enemy or entire party
    public enum SkillRange { single, multi }
    //defines what stat is affected as a result of the skill
    public enum AffectedStat { strength, armor, magic, resistance, agility }
    //defines what status effect the skill afflicts
    public enum StatusType { heal, buff, debuff, burn, poison }
    //defines what animation type is triggered by this skill
    public enum AnimationTrigger { Basic = 1, Physical = 2, Magical = 3, Status = 4, Damage = 5, Death = 6 }
    //defines the type of gear
    public enum GearType { helmet = 0, armor = 1, boots = 2, weapon = 3 }
}

public class CompareCharactersByAgi : IComparer<Character>
{
    // Characters with higher Agility stat will have higher priority in the battle order
    public int Compare(Character x, Character y)
    {
        return (int)(y.stats.TotalAgility) - (int)x.stats.TotalAgility;
    }
}
public class ComparePlayersByAgi : IComparer<Player>
{
    public new int Compare(Player x, Player y)
    {
        return (int)(y.stats.TotalAgility) - (int)x.stats.TotalAgility;
    }
}
public class CompareEnemiesByAgi : IComparer<Enemy>
{
    public new int Compare(Enemy x, Enemy y)
    {
        return (int)(y.stats.TotalAgility) - (int)x.stats.TotalAgility;
    }
}

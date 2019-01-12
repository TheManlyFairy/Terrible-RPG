using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public enum GameState { world, battle };
    //public GameState cameraState;

    public enum SkillType { physical, magical, status }
    public enum SkillRange { single, multi }
    public enum SkillTargeting { allyOnly, enemyOnly, allTargets }
    public enum AffectedStat { strength, armor, magic, resistance, agility }
    public enum StatusType { heal, buff, debuff, burn, poison }
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

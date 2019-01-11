using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombatAction
{
    // overload methods
    void CombatAction(CharacterStats actor, CharacterStats target);
    void CombatAction(CharacterStats actor, List<CharacterStats> targets);
}

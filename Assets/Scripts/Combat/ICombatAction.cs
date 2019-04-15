using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public interface ICombatAction
{
    void CombatAction(Character actor, Character target);
    void CombatAction(Character actor, List<Character> targets);
}

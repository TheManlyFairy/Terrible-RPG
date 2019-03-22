using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public interface ICombatAction
{
    void CombatAction(Character target);
    void CombatAction(List<Character> targets);
}

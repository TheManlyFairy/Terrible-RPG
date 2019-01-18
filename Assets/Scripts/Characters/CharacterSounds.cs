using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CharacterSounds : MonoBehaviour {

    AudioSource source;
    Character actor;
    void Start ()
    {
        source = GetComponent<AudioSource>();
        actor = GetComponent<Character>();
        actor.OnCombatActionPerformed += PlaySkillSFX;
	}

    public void PlaySkillSFX(ICombatAction combatAction)
    {
        if(combatAction is ScriptableSkill)
        {
            source.clip = (combatAction as ScriptableSkill).soundEffect;
            source.Play();
        }
    }
}

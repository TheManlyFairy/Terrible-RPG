using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterInformationBlock : MonoBehaviour
{
    public Text characterName;
    public Slider healthBar;
    public Slider manaBar;

    public void SetupCharacter(Character character)
    {
        characterName.text = character.name;
        healthBar.value = character.stats.HealthPercentage;
        manaBar.value = character.stats.ManaPercentage;
        character.OnHealthChange += UpdateHealthChange;
    }

    void UpdateHealthChange(float newValue)
    {
        healthBar.value = newValue;
    }
    void UpdateManaChange(float newValue)
    {
        manaBar.value = newValue;
    }
}
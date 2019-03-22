using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterInformationBlock : MonoBehaviour
{
    public Text characterName;
    public Image healthBar;
    public Image manaBar;

    public void SetupCharacter(Character character)
    {
        characterName.text = character.name;
        healthBar.fillAmount = character.stats.HealthPercentage;
        manaBar.fillAmount = character.stats.ManaPercentage;
        character.OnHealthChange += UpdateHealthChange;
    }

    void UpdateHealthChange(float newValue)
    {
        healthBar.fillAmount = newValue;
    }
    void UpdateManaChange(float newValue)
    {
        manaBar.fillAmount = newValue;
    }
}
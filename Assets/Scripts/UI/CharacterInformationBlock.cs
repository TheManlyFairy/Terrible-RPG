using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterInformationBlock : MonoBehaviour
{
    public Text characterName;
    public Image healthBar;
    public Image manaBar;
    [SerializeField]
    Character character;

    public void SetupCharacter(Character character)
    {
        this.character = character;
        characterName.text = character.name;
        healthBar.fillAmount = character.stats.HealthPercentage;
        manaBar.fillAmount = character.stats.ManaPercentage;
        character.OnHealthChange += UpdateHealthChange;
        character.OnManaChange += UpdateManaChange;
    }

    void UpdateHealthChange(float newValue)
    {
        healthBar.fillAmount = character.stats.HealthPercentage;
    }
    void UpdateManaChange(float newValue)
    {
        manaBar.fillAmount = character.stats.ManaPercentage;
    }
}
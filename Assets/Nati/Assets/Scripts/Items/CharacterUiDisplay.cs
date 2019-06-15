using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUiDisplay : MonoBehaviour
{

    [SerializeField] CharacterStats characterStats;
    public CharacterStats CharacterStats { get { return characterStats; } }
    
    public void UpdateEquipmentManager()
    {
        EquipmentManager.instance.UpdateSelectedCharacter(characterStats);
    }
}

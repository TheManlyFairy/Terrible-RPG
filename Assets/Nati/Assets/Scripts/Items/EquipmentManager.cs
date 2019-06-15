using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{

    public static EquipmentManager instance;

    public GameObject headSlot;
    public GameObject armorSlot;
    public GameObject weaponSlot;
    public GameObject bootsSlot;
    [SerializeField] CharacterStats selectedCharacter;

    public CharacterStats SelectedCharacter { get { return selectedCharacter; } }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
    }

    public void EquipmentDisplay(ScriptableEquipment equipment)
    {
        switch (equipment.GearType)
        {
            case Utility.GearType.helmet:
                UpdateEquipment(headSlot, equipment);
                break;
            case Utility.GearType.armor:
                UpdateEquipment(armorSlot, equipment);

                break;
            case Utility.GearType.weapon:
                UpdateEquipment(weaponSlot, equipment);

                break;
            case Utility.GearType.boots:
                UpdateEquipment(bootsSlot, equipment);
                break;
        }
    }

    public void UpdateEquipment(GameObject slot, ScriptableEquipment equipment)
    {
        slot.GetComponent<Image>().sprite = equipment.Icon;
        slot.GetComponent<EquipmentSlot>().Equipment = equipment;
        selectedCharacter.Equip(equipment);
    }

    public void UpdateSelectedCharacter(CharacterStats character)
    {
        selectedCharacter = character;
    }


}

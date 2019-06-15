using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    public GameObject scrollViewContent;
    public GameObject equipmentSlotPrefab;
    [SerializeField]
    ScriptableEquipment equipment;

    public ScriptableEquipment Equipment { set { equipment = value; } }

    public void Unequip()
    {
        if (equipment != null)
        {
            GameObject equipmentSlot = Instantiate(equipmentSlotPrefab, scrollViewContent.transform);
            equipmentSlot.GetComponentInChildren<EquipmentUIDisplay>().scriptableEquipment = equipment;
            EquipmentManager.instance.SelectedCharacter.Unequip(equipment);
            GetComponent<Image>().sprite = null;
            equipment = null;
        }
        else
            Debug.Log("There's nothing euqipt in " + this.name);

    }
}

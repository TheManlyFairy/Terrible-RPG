using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUIDisplay : MonoBehaviour
{

    public ScriptableEquipment scriptableEquipment;

    
    void Start()
    {
        UpdateItemIcon();
    }

    void UpdateItemIcon()
    {
        Image icon = GetComponent<Image>();
        icon.sprite = scriptableEquipment.Icon;
    }

    public void EquipItem()
    {
        EquipmentManager.instance.EquipmentDisplay(scriptableEquipment);
        Destroy(this.transform.parent.gameObject);
    }


}

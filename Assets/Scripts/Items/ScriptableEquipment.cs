using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

[CreateAssetMenu(menuName ="Items/Equipment")]
public class ScriptableEquipment : ScriptableItem
{
    public GearType gearType;
    public float bonusHealth;
    public float bonusMana;
    public float bonusStrength;
    public float bonusArmor;
    public float bonusMagic;
    public float bonusResistance;
    public float bonusAgility;
}

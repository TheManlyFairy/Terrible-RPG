using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Items/Constumable Item")]
public class ConsumableIteme : ScriptableItem
{
    public int maxStack = 10;
    public int stackCount = 1;
    public string statRecovery;
    public float healthRecovered;
    public float manaRecovered;

    public Sprite Icon { get { return icon; } }

    public string ItemName { get { return itemName; } }
}

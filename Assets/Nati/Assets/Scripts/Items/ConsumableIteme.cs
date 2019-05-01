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
    [SerializeField] float healthRecovered;
    [SerializeField] float manaRecovered;

    public ItemStatsChange statsChange;

    public Sprite Icon { get { return icon; } }
    public string ItemName { get { return itemName; } }
    public float HealthRecovered { get { return healthRecovered; } }
    public float ManaRecovered { get { return manaRecovered; } }

}

public enum ItemStatsChange
{
    Health,Mana
}

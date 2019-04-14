﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Items/Constumable Item")]
public class ConsumableIteme : ScriptableItem
{
    public int copyCount = 1;
    public float healthRecovered;
    public float manaRecovered;

    public Sprite Icon { get { return icon; } }
}
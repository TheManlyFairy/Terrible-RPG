using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using UnityEngine.UI;
public abstract class ScriptableItem : ScriptableObject
{
    [SerializeField]protected string itemName;
    [SerializeField]protected Sprite icon;
}

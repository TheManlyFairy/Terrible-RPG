using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIDisplay : MonoBehaviour
{

    public ConsumableIteme consumableIteme;
    public Text copyCountText;
    private int stackCount;

    void Start()
    {
        if (consumableIteme != null)
        {
            UpdateCopycount();
            UpdateItemIcon();
        }
    }

    void Update()
    {
        if (consumableIteme != null)
        {
            if (stackCount != consumableIteme.stackCount)
            {
                UpdateCopycount();
            }
        }
    }

    void UpdateCopycount()
    {
        stackCount = consumableIteme.stackCount;
        copyCountText.text = "" + stackCount;
    }

    void UpdateItemIcon()
    {
        Image icon = GetComponent<Image>();
        icon.sprite = consumableIteme.Icon;           
    }
}

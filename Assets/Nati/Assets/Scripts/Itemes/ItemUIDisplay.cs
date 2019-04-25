using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIDisplay : MonoBehaviour
{

    public ConsumableIteme consumableIteme;
    public Text copyCountText;
    private int stackCount;

    public Text itemNameText;
    public Text itemStatText;

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

    public void UpdateItemInfoText()
    {
        UIManager.instance.itemInfoPanel.SetActive(true);
        itemNameText.text = consumableIteme.ItemName;
        if(consumableIteme.healthRecovered > 0)
        itemStatText.text = consumableIteme.statRecovery + " " + consumableIteme.healthRecovered;
        else
            itemStatText.text = consumableIteme.statRecovery + " " + consumableIteme.manaRecovered;
    }

    public void HideItemInfoPanel()
    {
        UIManager.instance.itemInfoPanel.SetActive(false);
    }
}

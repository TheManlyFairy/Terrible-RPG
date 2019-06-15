using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIDisplay : MonoBehaviour
{

    public ConsumableIteme consumableIteme;
    public Text stackCountText;
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
        stackCountText.text = "" + stackCount;
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
        if(consumableIteme.HealthRecovered > 0)
        itemStatText.text = consumableIteme.statsChange + " " + consumableIteme.HealthRecovered;
        else
            itemStatText.text = consumableIteme.statRecovery + " " + consumableIteme.ManaRecovered;
    }

    public void HideItemInfoPanel()
    {
        UIManager.instance.itemInfoPanel.SetActive(false);
    }

    public void UseItem()
    {
        if (BattleManager.CurrentCharacter.stats.currentHealth == BattleManager.CurrentCharacter.stats.TotalHealth &&
            BattleManager.CurrentCharacter.stats.currentMana == BattleManager.CurrentCharacter.stats.TotalMana)
            return;

        switch (consumableIteme.statsChange)
        {
            case ItemStatsChange.Health:
                BattleManager.CurrentCharacter.stats.Heal(consumableIteme.HealthRecovered);
                break;
            case ItemStatsChange.Mana:
                BattleManager.CurrentCharacter.stats.Clarity(consumableIteme.ManaRecovered);
                break;

        }
        HideItemInfoPanel();

        if (stackCount <= 0)
            Destroy(this.gameObject);
        else
            stackCount--;
    }
}

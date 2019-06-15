using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject battleUI;
    public CharacterSkillsPanel skillPanel;

    //Nati
    public GameObject itemInfoPanel;
    public GameObject InventoryPanel;
    public GameObject equipmentPanel;

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            //GameManager.OnEnterBattle += DisplayBattleUI;
            GameManager.OnExitBattle += HideSkillsPanel;
            GameManager.OnExitBattle += HideBattleUI;
            skillPanel.Init();

            //Nati
            itemInfoPanel.SetActive(false);
            InventoryPanel.SetActive(false);
            equipmentPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowInventoryPanel();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowEquipmentPanel();
        }
    }

    public void ShowBattleUI()
    {
        instance.battleUI.SetActive(true);
    }
    public void HideBattleUI()
    {
        instance.battleUI.SetActive(false);

    }

    public void InterchangeSkillMenu()
    {
        if (skillPanel.isActiveAndEnabled)
            HideSkillsPanel();
        else
            ShowSkillsPanel();
    }
    public void ShowSkillsPanel()
    {
        //Debug.Log("Activating skill panel");
        instance.skillPanel.gameObject.SetActive(true);
        instance.skillPanel.UpdateSkillMenu();
    }
    public void HideSkillsPanel()
    {
        //Debug.Log("Deactivating skill panel");
        instance.skillPanel.RemoveCurrentSkillButtons();
        instance.skillPanel.gameObject.SetActive(false);
    }

    public void ShowInventoryPanel()
    {
        if (!InventoryPanel.activeSelf)
        {
            InventoryPanel.SetActive(true);
        }
        else
        {
            InventoryPanel.SetActive(false);

            if (itemInfoPanel.activeSelf)
                itemInfoPanel.SetActive(false);
        }
    }

    public void ShowEquipmentPanel()
    {
        if (!equipmentPanel.activeSelf)
        {
            equipmentPanel.SetActive(true);
        }
        else
        {
            equipmentPanel.SetActive(false);

            if (itemInfoPanel.activeSelf)
                itemInfoPanel.SetActive(false);
        }
    }
}

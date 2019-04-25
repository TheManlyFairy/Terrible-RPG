using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject battleUI;
    public CharacterSkillsPanel skillPanel;

    public GameObject itemInfoPanel;

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
            itemInfoPanel.SetActive(false);
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
}

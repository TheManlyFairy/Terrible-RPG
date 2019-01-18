using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject battleUI;
    public CharacterSkillsPanel skillPanel;

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameManager.OnEnterBattle += DisplayBattleUI;
            skillPanel.Init();
        }
    }

    void DisplayBattleUI()
    {
        battleUI.SetActive(true);
    }
    public void UpdateSkillPanel()
    {
        if (!skillPanel.gameObject.activeInHierarchy)
        {
            Debug.Log("Activating skill panel");
            skillPanel.gameObject.SetActive(true);
            skillPanel.UpdateSkillMenu();
        }
        else
        {
            Debug.Log("Deactivating skill panel");
            skillPanel.RemoveCurrentSkillButtons();
            skillPanel.gameObject.SetActive(false);
        }

    }
    public void HideMenus()
    {
        skillPanel.gameObject.SetActive(false);
    }
}

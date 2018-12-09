using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.IO;



public class UIButtonManager : MonoBehaviour {

    private GameObject startMenuPanel;
    private GameObject aboutPanel;
    private GameObject optionsPanel;
    private GameObject characterSelectPanel;

    public GameObject currentPanel;
    public GameObject previousPanel;

    public Text characterStatsText;
    public Text characterLore;

    private void Awake()
    {
        startMenuPanel = GameObject.Find("MainMenuePanel");
        optionsPanel = GameObject.Find("SettingsMenuePanel");
        optionsPanel.SetActive(false);
        characterSelectPanel = GameObject.Find("CharacterSelectPanel");
        characterSelectPanel.SetActive(false);
       
    }


    public void OnButtonClick()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        switch (name)
        {
            case "NewGameButton":
                OnNewGameButtonClick();
                currentPanel = characterSelectPanel;
                previousPanel = startMenuPanel;
                break;

            case "SettingsButton":
                Debug.Log(name);
                OnOptionsButtonClick();
                currentPanel = optionsPanel;
                previousPanel = startMenuPanel;
                break;

            case "AboutBtn":
                Debug.Log(name);
                OnAboutButtonClick();
                break;

            case "BackButton":
                OnBackButtonClick(currentPanel,previousPanel);
                break;

            case "LoadGameButton":
                OnLoagGameButtonClick();
                break;

            case "NunButton":
                OnHeroButtonClick();
                break;

            case "FatButton":
                OnHeroButtonClick();
                break;

            case "SushiButton":
                OnHeroButtonClick();
                break;

        }
    }

    private void OnNewGameButtonClick()
    {
        //Starts a new game go to Character Select page 

        startMenuPanel.SetActive(false);
        characterSelectPanel.SetActive(true);
      //  OnHeroButtonClick("Hero 1");

    }

    private void OnBackButtonClick(GameObject currenPanel, GameObject previousPanel)
    {
        currentPanel.SetActive(false);
        previousPanel.SetActive(true);
    }

    private void OnAboutButtonClick()
    {
        aboutPanel.SetActive(true);
        startMenuPanel.SetActive(false);
        Debug.Log(aboutPanel.name);

    }

    private void OnOptionsButtonClick()
    {
        optionsPanel.SetActive(true);
        startMenuPanel.SetActive(false);
    }

    
    private void OnHeroButtonClick()
    {
        characterStatsText.text = EventSystem.current.currentSelectedGameObject.GetComponent<CharacterInfo>().characterStats.ToString();
       characterLore.text =  ReadString(EventSystem.current.currentSelectedGameObject.GetComponent<CharacterInfo>().characterStats.characterName);
    }
    

    private void OnLoagGameButtonClick()
    {
        if(SceneManager.GetSceneByName("GameTestScene") != null)
        SceneManager.LoadScene("GameTestScene");
    }

   string ReadString( string characterLoreName)
    {
        string path = "Assets/Characters/" + characterLoreName + ".txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        string characterLore = reader.ReadToEnd();
        reader.Close();

        return characterLore.ToString();
    }

}

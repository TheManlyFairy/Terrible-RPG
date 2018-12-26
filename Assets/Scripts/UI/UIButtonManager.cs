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
    private GameObject videoSettingsPanel;
    private GameObject soundSettingsPanel;

    public GameObject currentPanel;
    public GameObject previousPanel;

    public Text characterStatsText;
    public Text characterLore;



   // public GameObject cubeTest;

    private void Awake()
    {
        startMenuPanel = GameObject.Find("MainMenuePanel");
        optionsPanel = GameObject.Find("SettingsMenuePanel");
        videoSettingsPanel = GameObject.Find("VideoSettingsPanel");
        soundSettingsPanel = GameObject.Find("SoundSettingsPanel");
        optionsPanel.SetActive(false);
        videoSettingsPanel.SetActive(false);
        soundSettingsPanel.SetActive(false);
        characterSelectPanel = GameObject.Find("CharacterSelectPanel");
        characterSelectPanel.SetActive(false);

        //cubeTest.GetComponent<MeshRenderer>().enabled = false;
       // cubeTest.GetComponent<BoxCollider>().enabled = false;
       
    }


    public void OnButtonClick()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        switch (name)
        {
            case "NewGameButton":
                OnNewGameButtonClick();
                OnHeroButtonClick();
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
            /*
            case "NunButton":
                OnHeroButtonClick();
                break;

            case "FatButton":
                OnHeroButtonClick();
                break;

            case "SushiButton":
                OnHeroButtonClick();
                break;
                */
            case "QuitButton":
                Application.Quit();
                break;
            case "VideoSettingsButton":
                    videoSettingsPanel.SetActive(true);
                    soundSettingsPanel.SetActive(false);

                break;
            case "SoundSettingsButton":
                soundSettingsPanel.SetActive(true);
                videoSettingsPanel.SetActive(false);

                break;
            case "RightButton":
                CharacterCameraSwitch.instance.NextCharacter();
                OnHeroButtonClick();
                break;

            case "LeftButton":
                CharacterCameraSwitch.instance.PreviousCharacter();
                OnHeroButtonClick();
                break;

        }
    }

    private void OnNewGameButtonClick()
    {
        //Starts a new game go to Character Select page 

        startMenuPanel.SetActive(false);
        characterSelectPanel.SetActive(true);
       // cubeTest.GetComponent<MeshRenderer>().enabled = true;
        //cubeTest.GetComponent<Animator>().SetBool("Animate", true);

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

    /*
    private void OnHeroButtonClick()
    {
        characterStatsText.text = EventSystem.current.currentSelectedGameObject.GetComponent<CharacterInfo>().characterStats.ToString();
       characterLore.text =  ReadString(EventSystem.current.currentSelectedGameObject.GetComponent<CharacterInfo>().characterStats.characterName);
    }
    */

    private void OnHeroButtonClick()
    {
        characterStatsText.text = CharacterCameraSwitch.instance.characterList[CharacterCameraSwitch.instance.currentCharacter].GetComponent<CharacterInfo>().characterStats.ToString();
        characterLore.text = ReadString(CharacterCameraSwitch.instance.characterList[CharacterCameraSwitch.instance.currentCharacter].GetComponent<CharacterInfo>().characterStats.characterName);
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

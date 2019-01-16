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
    private GameObject creditsPanel;
    private GameObject characterSelectButton;
    private GameObject nextCharacterButton;
    private GameObject PreviousCharacterButton;

    public GameObject currentCharacter;

    public GameObject currentPanel;
    public GameObject previousPanel;

    public Text characterStatsText;
    public Text characterLore;

    public List<GameObject> selectedCharacters;

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
        characterSelectButton = GameObject.Find("SelectCharacterButton");
        nextCharacterButton = GameObject.Find("NextCharacterButton");
        PreviousCharacterButton = GameObject.Find("PrevoiusCharacterButton");
        characterSelectPanel = GameObject.Find("CharacterSelectPanel");
        characterSelectPanel.SetActive(false);
        creditsPanel = GameObject.Find("CreditsPanel");
        creditsPanel.SetActive(false);

        nextCharacterButton.GetComponent<Button>().onClick.AddListener(OnNextButtonClick);
        PreviousCharacterButton.GetComponent<Button>().onClick.AddListener(OnPreviousButtonClick);
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

            case "CreditsButton":
                Debug.Log(name);
                OnCreditsButtonClick();
                currentPanel = creditsPanel;
                previousPanel = startMenuPanel;
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
            case "NextCharacterButton":
                CharacterCameraSwitch.instance.NextCharacter();
                OnHeroButtonClick();
                break;

            case "PrevoiusCharacterButton":
                CharacterCameraSwitch.instance.PreviousCharacter();
                OnHeroButtonClick();
                break;

            case "SelectCharacterButton":

                OnAddCharater();
                break;

            case "DeselectCharacterButton":
                
                OnRemoveCharacter();
                break;

        }
    }

    private void OnNewGameButtonClick()
    {
        //Starts a new game go to Character Select page 

        startMenuPanel.SetActive(false);
        characterSelectPanel.SetActive(true);
        currentCharacter = CharacterCameraSwitch.instance.characterList[CharacterCameraSwitch.instance.currentCharacter];
        // cubeTest.GetComponent<MeshRenderer>().enabled = true;
        //cubeTest.GetComponent<Animator>().SetBool("Animate", true);

    }

    private void OnBackButtonClick(GameObject currenPanel, GameObject previousPanel)
    {
        currentPanel.SetActive(false);
        previousPanel.SetActive(true);
    }

    private void OnCreditsButtonClick()
    {
        creditsPanel.SetActive(true);
        startMenuPanel.SetActive(false);
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

    void OnAddCharater()
    {
        //GameObject currentCharacter = CharacterCameraSwitch.instance.characterList[CharacterCameraSwitch.instance.currentCharacter];
        selectedCharacters.Add(currentCharacter);
        currentCharacter.GetComponent<CharacterInfo>().isSelected = true;
       characterSelectButton.SetActive(false);
    }

    void OnRemoveCharacter()
    {
       // GameObject currentCharacter = CharacterCameraSwitch.instance.characterList[CharacterCameraSwitch.instance.currentCharacter];
        Debug.Log("Removed Character: " + CharacterCameraSwitch.instance.characterList[CharacterCameraSwitch.instance.currentCharacter].name);
        selectedCharacters.Remove(currentCharacter);
        currentCharacter.GetComponent<CharacterInfo>().isSelected = false;
        characterSelectButton.SetActive(true);
    }

    void OnNextButtonClick()
    {
        currentCharacter = CharacterCameraSwitch.instance.characterList[CharacterCameraSwitch.instance.currentCharacter];
        characterSelectButton.SetActive(!currentCharacter.GetComponent<CharacterInfo>().isSelected);
    }

    void OnPreviousButtonClick()
    {
        currentCharacter = CharacterCameraSwitch.instance.characterList[CharacterCameraSwitch.instance.currentCharacter];
        characterSelectButton.SetActive(!currentCharacter.GetComponent<CharacterInfo>().isSelected);

    }

}

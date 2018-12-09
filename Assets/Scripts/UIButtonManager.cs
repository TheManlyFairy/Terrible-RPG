using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class UIButtonManager : MonoBehaviour {

   // public Sprite[] images;


    private GameObject startMenuPanel;
    private GameObject aboutPanel;
    private GameObject optionsPanel;
    private GameObject characterSelectPanel;
  //  private Image heroImage;

    private void Awake()
    {
        startMenuPanel = GameObject.Find("MainMenuePanel");
        optionsPanel = GameObject.Find("SettingsMenuePanel");
        optionsPanel.SetActive(false);
        aboutPanel = GameObject.Find("AboutPanel");
        aboutPanel.SetActive(false);
        //heroImage = GameObject.Find("CharacterSelectBackgroundImage").GetComponent<Image>();
        characterSelectPanel = GameObject.Find("CharacterSelectPanel");
        characterSelectPanel.SetActive(false);
       
    }


    public void OnButtonClick()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        switch (name)
        {
            case "NewGameBtn":
                OnNewGameButtonClick();
                break;

            case "SettingsButton":
                Debug.Log(name);
                OnOptionsButtonClick();
                break;

            case "AboutBtn":
                Debug.Log(name);
                OnAboutButtonClick();
                break;

            case "BackButton":
                OnOptionBackButtonClick();
                break;

          //  case "Hero 1":
          //      OnHeroButtonClick(name);
          //      break;
          //
          //  case "Hero 2":
          //      OnHeroButtonClick(name);
          //      break;
          //
          //  case "Hero 3":
          //      OnHeroButtonClick(name);
          //      break;
          //
          //  case "Hero 4":
          //      OnHeroButtonClick(name);
          //      break;
        }
    }

    private void OnNewGameButtonClick()
    {
        //Starts a new game go to Character Select page 

        startMenuPanel.SetActive(false);
        characterSelectPanel.SetActive(true);
      //  OnHeroButtonClick("Hero 1");

    }

    private void OnOptionBackButtonClick()
    {
        optionsPanel.SetActive(false);
        startMenuPanel.SetActive(true);
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
    private void OnHeroButtonClick(string buttonName)
    {
        string[] s = buttonName.Split(' ');
        int index = int.Parse(s[1]);
        heroImage.sprite = images[index-1];
    }
    */



}

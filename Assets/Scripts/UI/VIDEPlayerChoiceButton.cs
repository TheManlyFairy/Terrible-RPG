using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VIDE_Data;
public class VIDEPlayerChoiceButton : MonoBehaviour
{
    public Text choice;
    public int choiceCommentIndex;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            VIDEDialogueManager.instance.ChoiceSelected(choiceCommentIndex);
        });
    }
}

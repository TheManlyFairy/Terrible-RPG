using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VIDE_Data;
public class VIDEDialogueManager : MonoBehaviour
{
    public static VIDEDialogueManager instance;
    public GameObject dialogueContainer;
    public GameObject playerChoiceContainer;
    public Text speakerName;
    public Text dialogue;
    public VIDEPlayerChoiceButton choiceButtonPrefab;
    List<VIDEPlayerChoiceButton> choiceButtons;
    // Start is called before the first frame update
    void Start()
    {
        if(instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            dialogueContainer.SetActive(false);
            playerChoiceContainer.SetActive(false);
            choiceButtonPrefab.gameObject.SetActive(false);
            choiceButtons = new List<VIDEPlayerChoiceButton>();
        }
    }

    // Update is called once per frame
    
    public static void Interact(VIDE_Assign VDAssign)
    {
        if (!VD.isActive)
            instance.Begin(VDAssign);
        else
            VD.Next();
    }
    void Begin(VIDE_Assign VDAssign)
    {
        dialogueContainer.SetActive(true);
        playerChoiceContainer.SetActive(false);
        VD.OnNodeChange += instance.UpdateUI;
        VD.OnEnd += End;
        VD.BeginDialogue(VDAssign);
    }
    void UpdateUI(VD.NodeData data)
    {
        speakerName.text = data.tag;
        if(data.isPlayer)
        {
            playerChoiceContainer.SetActive(true);
            ClearPreviousChoices();
            SetupPlayerChoices(data);
        }
        else
        {
            playerChoiceContainer.SetActive(false);
            dialogue.text = data.comments[data.commentIndex];
        }
    }
    void ClearPreviousChoices()
    {
        for(int i=0; i<choiceButtons.Count; i++)
        {
            Destroy(choiceButtons[i].gameObject);
        }
        choiceButtons.Clear();
    }
    void SetupPlayerChoices(VD.NodeData data)
    {
        for(int i=0; i<data.comments.Length; i++)
        {
            choiceButtons.Add(Instantiate(choiceButtonPrefab));
            choiceButtons[i].gameObject.SetActive(true);
            choiceButtons[i].transform.SetParent(playerChoiceContainer.transform);
            choiceButtons[i].choiceCommentIndex = i;
            choiceButtons[i].choice.text = data.comments[i];
        }
    }
    public void ChoiceSelected(int commentIndex)
    {
        VD.nodeData.commentIndex = commentIndex;
        VD.Next();
    }
    void End(VD.NodeData data)
    {
        dialogueContainer.SetActive(false);
        playerChoiceContainer.SetActive(false);
        VD.OnNodeChange -= instance.UpdateUI;
        VD.OnEnd -= End;
        VD.EndDialogue();
    }
}

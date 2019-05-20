using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Utility;

public class CharacterInterface : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform worldCanvas;
    Character character;

    private void Start()
    {
        character = GetComponent<Character>();
        worldCanvas = GameObject.FindGameObjectWithTag("WorldCanvas").transform;
        
    }
    private void OnMouseOver()
    {
        
    }
    bool ThisIsValidTarget()
    {
        bool isValid = false;
        if (GameManager.gameState == GameState.battle)
        {
            if (BattleManager.battleStage == BattleStage.targetSelection)
            {
                SkillTargeting currentCharacterTargeting = (BattleManager.CurrentCharacter.combatAction as ScriptableSkill).skillTargeting;
                switch ((BattleManager.CurrentCharacter.combatAction as ScriptableSkill).skillTargeting)
                {
                    case SkillTargeting.playerOnly:
                        if (character is Player)
                            isValid = true;
                        break;
                    case SkillTargeting.enemyOnly:
                        if (character is Enemy)
                            isValid = true;
                        break;
                    case (SkillTargeting.allTargets):
                        isValid = true;
                        break;
                }
            }
        }
        return isValid;
    }
    private void OnMouseEnter()
    {
        Debug.Log("Checking " + gameObject.name);
        if (ThisIsValidTarget())
        {
            worldCanvas.transform.position = transform.position;
        }
        else
        {
            Debug.Log("Invalid");
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Checking " + gameObject.name);
        if (ThisIsValidTarget())
        {
            worldCanvas.transform.position = transform.position;
        }
        else
        {
            Debug.Log("Invalid");
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    
}

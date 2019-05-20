using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class CameraManager : MonoBehaviour {

    GameManager gameManager;
    Animator animator;
	void Start ()
    {
        gameManager = GameManager.instance;
        animator = GetComponent<Animator>();

        GameManager.OnEnterBattle += TriggerWorldToBattleTransition;
        GameManager.OnExitBattle += TriggerBattleToWorldTransition;
    }
    void TriggerWorldToBattleTransition()
    {
        animator.SetTrigger("WorldToBattleState");
    }
    void TriggerBattleToWorldTransition()
    {
        animator.SetTrigger("BattleToWorldState");
    }

   /* Camera Transition TEST
    * void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (gameManager.CurrentGameState == GameState.world)
            {
                gameManager.CurrentGameStat = GameState.battle;
                TriggerWorldToBattleTransition();
            }
            else
            {
                gameManager.gameState = GameState.world;
                TriggerBattleToWorldTransition();
            }
        }
    }*/
}

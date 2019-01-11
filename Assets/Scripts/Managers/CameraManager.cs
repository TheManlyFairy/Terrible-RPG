using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class CameraManager : MonoBehaviour {

    GameManager gameManager;
    Animator animator;
	void Start ()
    {
        gameManager = GameManager.gameManager;
        animator = GetComponent<Animator>();

        GameManager.OnEnterBattle += TriggerWorldToBattleTransition;
    }
    void TriggerWorldToBattleTransition()
    {
        animator.SetTrigger("WorldToBattleState");
    }
    void TriggerBattleToWorldTransition()
    {
        animator.SetTrigger("BattleToWorldState");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (gameManager.gameState == GameState.world)
            {
                gameManager.gameState = GameState.battle;
                TriggerWorldToBattleTransition();
            }
            else
            {
                gameManager.gameState = GameState.world;
                TriggerBattleToWorldTransition();
            }
        }
    }
}

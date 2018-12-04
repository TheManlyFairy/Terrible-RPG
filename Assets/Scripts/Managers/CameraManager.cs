using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    GameManager gameManager;
    Animator animator;
	void Start ()
    {
        gameManager = GameManager.gameManager;
        animator = GetComponent<Animator>();
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
            if (gameManager.gameState == Utility.GameState.world)
            {
                gameManager.gameState = Utility.GameState.battle;
                TriggerWorldToBattleTransition();
            }
            else
            {
                gameManager.gameState = Utility.GameState.world;
                TriggerBattleToWorldTransition();
            }
        }
    }
}

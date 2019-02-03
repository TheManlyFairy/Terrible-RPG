using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class GameManager : MonoBehaviour
{
    public static Action OnEnterBattle;
    public static Action OnExitBattle;
    public static GameManager gameManager;
    public static List<Player> partyMembers;
    GameState gameState;

    public GameState CurrentGameState { get { return gameState; } }

    void Awake()
    {
        if (gameManager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            gameManager = this;
        }
    }

    public static void EnterBattleMode()
    {
        gameManager.gameState = GameState.battle;
        if (OnEnterBattle != null)
        {
            OnEnterBattle();
        }

    }
    public static void ExitBattleMode()
    {
        gameManager.gameState = GameState.world;
        if (OnExitBattle != null)
        {
            OnExitBattle();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class GameManager : MonoBehaviour
{
    public static Action OnEnterBattle;
    public static Action OnExitBattle;
    public static GameManager instance;
    public static List<Player> partyMembers;
    public static GameState gameState;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public static void EnterBattleMode()
    {
        gameState = GameState.battle;
        if (OnEnterBattle != null)
        {
            OnEnterBattle();
        }

    }
    public static void ExitBattleMode()
    {
        gameState = GameState.world;
        if (OnExitBattle != null)
        {
            OnExitBattle();
        }
    }
}

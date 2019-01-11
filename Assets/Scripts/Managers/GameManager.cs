using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class GameManager : MonoBehaviour
{
    public static Action OnEnterBattle;
    public static GameManager gameManager;
    public static List<Player> partyMembers;
    public GameState gameState;
    
    void Awake()
    {
        if(gameManager !=null)
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
        if(OnEnterBattle !=null)
        {
            OnEnterBattle();
        }

    }
}

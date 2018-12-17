using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action OnEnterBattle;
    public static GameManager gameManager;
    public static List<Player> partyMembers;
    public Utility.GameState gameState;
    
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
        gameManager.gameState = Utility.GameState.battle;
        if(OnEnterBattle !=null)
        {
            OnEnterBattle();
        }

    }
}

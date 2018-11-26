using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public static List<Player> partyMembers;
    
    void Start()
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
}

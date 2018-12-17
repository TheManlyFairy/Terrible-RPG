using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    public float delayTimeBeforePartyReveals;
    public List<Character> showList;
    
    public static BattleManager battleManager;
    public static List<Character> battleOrder;
    //public static List<Player> playerParty;
    //public static List<Enemy> enemyParty;

    void Awake()
    {
        if(battleManager !=null)
        {
            Destroy(gameObject);
        }
        else
        {
            battleManager = this;
            battleOrder = new List<Character>();
        }
        
        
        //playerParty = new List<Player>();
        //enemyParty = new List<Enemy>();
    }

    public static void BattleStart(List<Character> playerParty, List<Character> enemyParty)
    {
        battleOrder.AddRange(playerParty);
        battleOrder.AddRange(enemyParty);
        battleOrder.Sort(new CompareCharactersByAgi());
        battleManager.showList = battleOrder;
        GameManager.EnterBattleMode();
    }


    void PlayTurn()
    {
        StartCoroutine(TurnPhasePlay());
    }
    IEnumerator TurnPhasePlay()
    {
        Vector3 targetPos;
        float timer;
        foreach (Character c in battleOrder)
        {
            targetPos = c.transform.position + c.transform.forward;
            timer = 0;

            while (timer<1)
            {
                timer += Time.deltaTime;
                c.transform.position = Vector3.Lerp(c.transform.position, targetPos, timer);
                yield return null;
            }

            c.Attack(battleOrder[Random.RandomRange(0, battleOrder.Count)]);

            yield return new WaitForSeconds(0.2f);

            targetPos = c.transform.position - c.transform.forward;
            timer = 0;

            while (timer<1)
            {
                timer += Time.deltaTime;
                c.transform.position = Vector3.Lerp(c.transform.position, targetPos, timer);
                yield return null;
            }
        }
    }
    
    /*void SetupEnemyPartyList()
     {
         enemyParty = new List<Enemy>();
         foreach (Character c in battleOrder)
         {
             if (c.GetType().Equals(typeof(Enemy)))
                enemyParty.Add((Enemy)c);

         }
        enemyParty.Sort(new CompareEnemiesByAgi());
     }*/
}

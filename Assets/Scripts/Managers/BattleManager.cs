using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utility;

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
        if (battleManager != null)
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
        battleManager.PlayTurn();
    }


    void PlayTurn()
    {
        StartCoroutine(PlayTurnPhase());
    }
    void SetupTurn()
    {
        StartCoroutine(SetupTurnPhase());
    }

    List<CharacterStats> returnEnemyStats()
    {
        List<CharacterStats> enemyStats = new List<CharacterStats>();
        foreach (Character c in battleOrder)
        {
            if (c.GetType().Equals(typeof(Enemy)))
            {
                enemyStats.Add(c.stats);
            }
                
        }
        return enemyStats;
    }

    IEnumerator PlayTurnPhase()
    {
        Vector3 targetPos;
        float timer;
        for (int i = 0; i < 4; i++)
        {
            Debug.LogWarning("playing turn " + (i + 1));
            foreach (Character c in battleOrder)
            {
                targetPos = c.transform.localPosition + c.transform.forward;
                timer = 0;

                while (timer < 1)
                {
                    timer += Time.deltaTime;
                    c.transform.localPosition = Vector3.Lerp(c.transform.localPosition, targetPos, timer);
                    yield return null;
                }
                Character target = battleOrder[Random.Range(0, battleOrder.Count)];
                //c.Attack(target);
                c.combatAction = c.basicAttack;
                
                if (c.basicAttack.skillRange == SkillRange.single)
                {
                    Debug.Log(c + " targeted " + target + " using " + c.combatAction);
                    c.combatAction.CombatAction(c.stats, target.stats);
                }
                   
                if (c.basicAttack.skillRange == SkillRange.multi)
                {
                    Debug.Log(c + " targeted all enemies using " + c.combatAction);
                    c.combatAction.CombatAction(c.stats, returnEnemyStats());
                }
                    

                yield return new WaitForSeconds(0.2f);

                targetPos = c.transform.localPosition - c.transform.forward;
                timer = 0;

                while (timer < 1)
                {
                    timer += Time.deltaTime;
                    c.transform.localPosition = Vector3.Lerp(c.transform.localPosition, targetPos, timer);
                    yield return null;
                }
            }
            foreach(Character c in battleOrder)
            {
                c.CountdownStatuses();
            }
        }
    }
    IEnumerator SetupTurnPhase()
    {



        yield return null;
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

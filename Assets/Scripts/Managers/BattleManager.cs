using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    public List<Character> battleOrder;
    public List<Player> partyMembers;
    public List<Enemy> enemyParty;

    // Use this for initialization
    void Start()
    {

        battleOrder = FindObjectsOfType<Character>().OfType<Character>().ToList();
        battleOrder.Sort(new CompareCharactersByAgi());
        PlayTurn();
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

    void SetupEnemyPartyList()
     {
         enemyParty = new List<Enemy>();
         foreach (Character c in battleOrder)
         {
             if (c.GetType().Equals(typeof(Enemy)))
                enemyParty.Add((Enemy)c);

         }
        enemyParty.Sort(new CompareEnemiesByAgi());
     }
}

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
    public static List<Character> playerParty;
    public static List<Character> enemyParty;
    static Character currentCharacter;

    public static Character CurrentCharacter { get { return currentCharacter; } }

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
        BattleManager.playerParty = playerParty;
        BattleManager.enemyParty = enemyParty;
        battleOrder.AddRange(playerParty);
        battleOrder.AddRange(enemyParty);
        battleOrder.Sort(new CompareCharactersByAgi());
        battleManager.showList = battleOrder;
        GameManager.EnterBattleMode();
        battleManager.SetupTurn();
    }

    public void SelectCharacterBasicAttack()
    {
        currentCharacter.combatAction = currentCharacter.basicAttack;
    }
    public void SelectCharacterSkill(int index)
    {
        currentCharacter.combatAction = currentCharacter.skills[index];
    }

    void PlayTurn()
    {
        StartCoroutine(PlayTurnPhase());
    }
    void SetupTurn()
    {
        StartCoroutine(SetupTurnPhase());
    }
    void EmptyCombatActions()
    {
        foreach(Character character in battleOrder)
        {
            character.combatAction = null;
        }
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
        foreach (Character character in battleOrder)
        {
            targetPos = character.transform.localPosition + character.transform.forward;
            timer = 0;

            while (timer < 1)
            {
                timer += Time.deltaTime;
                character.transform.localPosition = Vector3.Lerp(character.transform.localPosition, targetPos, timer);
                yield return null;
            }
            Character target = battleOrder[Random.Range(0, battleOrder.Count)];
            //c.Attack(target);
            //c.combatAction = c.basicAttack;

            if ((character.combatAction as ScriptableSkill).skillRange == SkillRange.single)
            {
                Debug.Log(character + " targeted " + target + " using " + character.combatAction);
                character.PerformAction(target);
            }

            if ((character.combatAction as ScriptableSkill).skillRange == SkillRange.multi)
            {
                Debug.Log(character + " targeted all enemies using " + character.combatAction);
                character.PerformAction(enemyParty);
            }

            yield return new WaitForSeconds(character.animator.GetCurrentAnimatorClipInfo(0).Length+0.2f);

            targetPos = character.transform.localPosition - character.transform.forward;
            timer = 0;

            while (timer < 1)
            {
                timer += Time.deltaTime;
                character.transform.localPosition = Vector3.Lerp(character.transform.localPosition, targetPos, timer);
                yield return null;
            }
        }
        foreach (Character character in battleOrder)
        {
            character.CountdownStatuses();
        }

        EmptyCombatActions();
        StartCoroutine(SetupTurnPhase());
    }
    IEnumerator SetupTurnPhase()
    {
        for (int partyIndex = 0; partyIndex < playerParty.Count; partyIndex++)
        {
            currentCharacter = playerParty[partyIndex];
            Debug.Log("Now setting up " + currentCharacter.name);
            while (currentCharacter.combatAction == null)
            {
                yield return null;
                if (Input.GetKeyDown(KeyCode.Escape) && partyIndex > 0)
                {
                    partyIndex--;
                    currentCharacter = playerParty[partyIndex];
                    currentCharacter.combatAction = null;
                    Debug.Log("Returning to " + currentCharacter.name);
                    UIManager.instance.UpdateSkillPanel();
                }
            }
            yield return null;
        }
        foreach (Character enemy in enemyParty)
        {
            enemy.combatAction = enemy.basicAttack;
        }
        yield return null;
        StartCoroutine(PlayTurnPhase());
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

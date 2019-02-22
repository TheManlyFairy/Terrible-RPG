using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utility;

public class BattleManager : MonoBehaviour
{

    public float delayTimeBeforePartyReveals;
    public List<Character> showList;

    public static BattleManager instance;
    public static List<Character> battleOrder;
    public static List<Character> playerParty;
    public static List<Character> enemyParty;
    public LayerMask targetingMask;
    static Character currentCharacter;

    public static Character CurrentCharacter { get { return currentCharacter; } }

    PartyManager playerPartyManager;
    PartyManager enemyPartyManager;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            battleOrder = new List<Character>();
        }

        //playerParty = new List<Player>();
        //enemyParty = new List<Enemy>();

    }

    public static void BattleStart(PartyManager playerPartyManager, PartyManager enemyPartyManager)
    {
        instance.playerPartyManager = playerPartyManager;
        instance.enemyPartyManager = enemyPartyManager;
        BattleManager.playerParty = playerPartyManager.party;
        BattleManager.enemyParty = enemyPartyManager.party;
        battleOrder.AddRange(playerParty);
        battleOrder.AddRange(enemyParty);
        battleOrder.Sort(new CompareCharactersByAgi());
        instance.showList = battleOrder;
        GameManager.EnterBattleMode();
        instance.SetupTurn();
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
        foreach (Character character in battleOrder)
        {
            character.combatAction = null;
            character.target = null;
        }
    }
    bool AllEnemiesDefeated()
    {
        List<Character> livingEnemies;
        livingEnemies = enemyParty.Where(enemy => enemy.IsAlive).ToList();
        //Debug.LogWarning("Living enemies: " + livingEnemies.Count);
        return livingEnemies.Count == 0;
    }
    Character SelectTarget()
    {
        int mask = 1 << 10;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, targetingMask);
        Debug.Log("clicked "+hit.collider.name);
        return hit.collider.GetComponent<Character>();

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
        UIManager.instance.HideBattleUI();
        Vector3 targetPos;
        float timer;
        foreach (Character character in battleOrder)
        {
            if (character.IsAlive && !AllEnemiesDefeated())
            {
                targetPos = character.transform.localPosition + character.transform.forward;
                timer = 0;

                while (timer < 1)
                {
                    timer += Time.deltaTime;
                    character.transform.localPosition = Vector3.Lerp(character.transform.localPosition, targetPos, timer);
                    yield return null;
                }
                //Character target = battleOrder[Random.Range(0, battleOrder.Count)];

                if ((character.combatAction as ScriptableSkill).skillRange == SkillRange.single)
                {
                    Debug.Log(character + " targeted " + character.target.name + " using " + character.combatAction);
                    character.PerformAction();
                }

                if ((character.combatAction as ScriptableSkill).skillRange == SkillRange.multi)
                {
                    Debug.Log(character + " targeted all enemies using " + character.combatAction);
                    character.PerformAction(enemyParty);
                }

                yield return new WaitForSeconds(character.Animator.GetCurrentAnimatorStateInfo(0).length);

                targetPos = character.transform.localPosition - character.transform.forward;
                timer = 0;

                while (timer < 1)
                {
                    timer += Time.deltaTime;
                    character.transform.localPosition = Vector3.Lerp(character.transform.localPosition, targetPos, timer);
                    yield return null;
                }
            }
            yield return null;
        }
        foreach (Character character in battleOrder)
        {
            if(character.IsAlive)
                character.CountdownStatuses();
        }

        EmptyCombatActions();

        if (AllEnemiesDefeated())
        {
            GameManager.ExitBattleMode();
            yield return new WaitForSeconds(.5f);
            Destroy(enemyPartyManager.gameObject);
            playerPartyManager.HideAllButFirst();
        }
            
        else
            StartCoroutine(SetupTurnPhase());
    }
    IEnumerator SetupTurnPhase()
    {
        UIManager.instance.ShowBattleUI();
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
                    currentCharacter.target = null;
                    Debug.Log("Returning to " + currentCharacter.name);
                    UIManager.instance.ShowSkillsPanel();
                }
            }
            if (currentCharacter.combatAction is ScriptableSkill)
            {
                if ((currentCharacter.combatAction as ScriptableSkill).skillRange == SkillRange.single)
                {
                    Debug.Log("selecting target");
                    while (currentCharacter.target == null)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            currentCharacter.target = SelectTarget();
                            //Debug.Log("targeted " + currentCharacter.target.name);
                        }
                        if (Input.GetKeyDown(KeyCode.Escape) && partyIndex > 0)
                        {
                            partyIndex--;
                            currentCharacter = playerParty[partyIndex];
                            currentCharacter.combatAction = null;
                            currentCharacter.target = null;
                            Debug.Log("Returning to " + currentCharacter.name);
                            UIManager.instance.ShowSkillsPanel();
                        }
                        yield return null;
                    }
                }
            }
            yield return null;
        }
        foreach (Character enemy in enemyParty)
        {
            enemy.combatAction = enemy.basicAttack;
            if(enemy.basicAttack.skillRange == SkillRange.single)
            {
                Character enemyTarget = playerParty[Random.Range(0, playerParty.Count - 1)];
                Debug.Log(enemy.name + " set up to target " + enemyTarget);
                enemy.target = enemyTarget;
            }
            else
            {
                Debug.Log(enemy.name + " using a multi targeted attack");
            }
                
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

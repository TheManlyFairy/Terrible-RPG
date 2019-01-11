using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    public List<Character> party;
    void Start()
    {
        HideAllButFirst();
        GameManager.OnEnterBattle += RevealAllParty;
    }

    protected void HideAllButFirst()
    {
        foreach (Character c in party)
        {
            c.gameObject.SetActive(false);
        }
        party[0].gameObject.SetActive(true);
        party[0].gameObject.transform.localPosition = Vector3.zero;
    }
    protected void RevealAllParty()
    {
        StartCoroutine(RevealDelay());
    }

    IEnumerator RevealDelay()
    {
        yield return new WaitForSeconds(BattleManager.battleManager.delayTimeBeforePartyReveals);

        foreach (Character c in party)
        {
            c.gameObject.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    [SerializeField]
    Character partyLeader;
    public List<Character> party;

    public Character PartyLeader { get { return partyLeader; } }

   
    protected void SortPartyPositions()
    {
        int positionModifier = 0;
        foreach(Character character in party)
        {
            character.transform.localPosition = new Vector3(positionModifier, character.transform.localPosition.y, 0);
            positionModifier -= 3;
        }
    }
    public void HideAllButFirst()
    {
        foreach (Character c in party)
        {
            c.gameObject.SetActive(false);
        }
        partyLeader.gameObject.SetActive(true);
    }
    protected void RevealAllParty()
    {
        //StartCoroutine(RevealDelay());
        foreach (Character c in party)
        {
            c.gameObject.SetActive(true);
        }
    }
    protected void FindPartyMembers()
    {
        party = GetComponentsInChildren<Character>().ToList();
        partyLeader = party[0];
    }
    IEnumerator RevealDelay()
    {
        yield return new WaitForSeconds(BattleManager.instance.delayTimeBeforePartyReveals);

        foreach (Character c in party)
        {
            c.gameObject.SetActive(true);
        }
    }
}

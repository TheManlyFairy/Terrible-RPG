using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPartyManager : PartyManager
{
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collided with "+col.gameObject.name);
        if (col.gameObject.layer == LayerMask.NameToLayer("WildEnemy"))
        {
            StartCoroutine(DelayPositioning(col));
        }
    }

    IEnumerator DelayPositioning(Collision col)
    {
        BattleManager.BattleStart(party, col.gameObject.GetComponent<PartyManager>().party);

        yield return new WaitForSeconds(BattleManager.battleManager.delayTimeBeforePartyReveals);
        
        transform.Translate(-transform.forward * 6);
        col.transform.Translate(transform.forward * 6);
    }
}

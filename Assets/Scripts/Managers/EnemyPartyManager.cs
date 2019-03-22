using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPartyManager : PartyManager {

    [SerializeField]
    int totalExpValue=0;

    public int TotalExpValue { get { return totalExpValue; } }
    void Start()
    {
        FindPartyMembers();
        SortPartyPositions();
        HideAllButFirst();
        CalculateTotalEXP();
        //GameManager.OnEnterBattle += RevealAllParty;
    }

    void CalculateTotalEXP()
    {

        foreach(Enemy e in party)
        {
            totalExpValue += e.ExpValue;
        }
    }
    public override void RevealAllParty()
    {
        RotateEnemyToFacePlayer();
        base.RevealAllParty();
    }
	public void RotateEnemyToFacePlayer()
    {
        SortPartyPositions();
        foreach(Character character in party)
        {
            Debug.Log("Rotating " + character.gameObject.name);
            character.transform.localEulerAngles = new Vector3(0, 180, 0);
        }
    }

}

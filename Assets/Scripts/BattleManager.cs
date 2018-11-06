using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public List<Character> battleOrder;
	// Use this for initialization
	void Start ()
    {
        battleOrder = FindObjectsOfType<Character>().OfType<Character>().ToList();
        battleOrder.Sort(new CompareCharactersByAgi());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

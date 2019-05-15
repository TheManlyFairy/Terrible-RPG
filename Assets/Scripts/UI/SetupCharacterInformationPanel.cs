using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupCharacterInformationPanel : MonoBehaviour {

    public CharacterInformationBlock characterInformationPrefab;
    List<Character> playerParty;
    
	public void Setup()
    {
        playerParty = FindObjectOfType<PlayerPartyManager>().party;
        foreach(Character character in playerParty)
        {
            CharacterInformationBlock charInfo = Instantiate(characterInformationPrefab);
            charInfo.gameObject.SetActive(true);
            charInfo.transform.parent = transform;
            charInfo.transform.localScale = Vector3.one;
            charInfo.SetupCharacter(character);
        }
    }
}

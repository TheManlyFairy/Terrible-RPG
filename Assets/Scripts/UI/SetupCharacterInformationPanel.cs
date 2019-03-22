using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupCharacterInformationPanel : MonoBehaviour {

    public CharacterInformationBlock characterInformationPrefab;

    void Start()
    {
        GameManager.OnEnterBattle += Setup;
    }
	void Setup()
    {
        
        foreach(Character character in BattleManager.playerParty)
        {
            CharacterInformationBlock charInfo = Instantiate(characterInformationPrefab);
            charInfo.gameObject.SetActive(true);
            charInfo.transform.parent = transform;
            charInfo.transform.localScale = Vector3.one;
            charInfo.SetupCharacter(character);
        }
    }
}

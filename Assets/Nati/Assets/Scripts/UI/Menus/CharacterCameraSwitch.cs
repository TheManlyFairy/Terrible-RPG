using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCameraSwitch : MonoBehaviour {

    public static CharacterCameraSwitch instance;

    public List<GameObject> characterList;
   public int currentCharacter;
    Cinemachine.CinemachineVirtualCamera virtualCamera;

    void Awake()
    {
        if(instance == null)
        instance = this;

        virtualCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
        currentCharacter = 0;
        virtualCamera.Follow = characterList[currentCharacter].transform;
    }

   public void NextCharacter()
    {
        currentCharacter++;

        if (currentCharacter <= (characterList.Count-1))
        {
            virtualCamera.Follow = characterList[currentCharacter].transform;
        }
        if(currentCharacter > (characterList.Count-1))
        {
            currentCharacter = 0;
            virtualCamera.Follow = characterList[currentCharacter].transform;
        }
    }

    public void PreviousCharacter()
    {
        currentCharacter--;

        if (currentCharacter >= 0)
        {
            virtualCamera.Follow = characterList[currentCharacter].transform;
        }

        if(currentCharacter < 0)
        {
            currentCharacter = characterList.Count - 1;
            virtualCamera.Follow = characterList[currentCharacter].transform;
        }
    }
}

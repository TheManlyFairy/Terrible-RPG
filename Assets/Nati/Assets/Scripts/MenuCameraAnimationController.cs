using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraAnimationController : MonoBehaviour
{

    Animation animation;

    void Start()
    {
        animation = GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            animation["NewGameFocus"].speed = 1;
            animation["NewGameFocus"].time = 0;
            animation.Play("NewGameFocus");

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            animation["NewGameFocus"].speed = -1;
            animation["NewGameFocus"].time = animation["NewGameFocus"].length;
            animation.Play("NewGameFocus");
        }      
    }

    public void FocusNewGame()
    {
        animation["NewGameFocus"].speed = 1;
        animation["NewGameFocus"].time = 0;
        animation.Play("NewGameFocus");
    }

    public void ResetPosition()
    {
        animation["NewGameFocus"].speed = -1;
        animation["NewGameFocus"].time = animation["NewGameFocus"].length;
        animation.Play("NewGameFocus");
    }
}

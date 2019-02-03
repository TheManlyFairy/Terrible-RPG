using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Utility;

public class PlayerControls : MonoBehaviour
{

    public float moveSpeed = 5;
    CharacterAnimator partyLeadAnimator;
    GameManager gameManager;
    Rigidbody rigBody;

    void Start()
    {
        gameManager = GameManager.gameManager;
        rigBody = GetComponent<Rigidbody>();
        partyLeadAnimator = GetComponent<PartyManager>().PartyLeader.GetComponent<CharacterAnimator>();
    }

    void FixedUpdate()
    {
        if (gameManager.CurrentGameState == GameState.world)
            Move();
    }

    void Move()
    {
        Vector3 moveDirection = Vector3.zero;
        Vector3 lookDirection = transform.forward;

        if (Input.GetKey(KeyCode.A))
            moveDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D))
            moveDirection += Vector3.right;
        if (Input.GetKey(KeyCode.W))
            moveDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S))
            moveDirection += Vector3.back;

        partyLeadAnimator.TriggerWorldAnimations(moveDirection);
        

        rigBody.velocity = moveDirection * moveSpeed;
    }
}

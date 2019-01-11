using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class PlayerControls : MonoBehaviour {

    public float moveSpeed = 5 ;
    GameManager gameManager;
    Rigidbody rigBody;

    void Start()
    {
        gameManager = GameManager.gameManager;
        rigBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(gameManager.gameState == GameState.world)
            Move();
    }

    void Move()
    {
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
            moveDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D))
            moveDirection += Vector3.right;
        if (Input.GetKey(KeyCode.W))
            moveDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S))
            moveDirection += Vector3.back;

        rigBody.velocity = moveDirection * moveSpeed;
    }
}

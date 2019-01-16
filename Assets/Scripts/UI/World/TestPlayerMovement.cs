using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour {

    public int movementSpeed = 10;
    public int rotationSpeed = 20;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticleInput = Input.GetAxis("Vertical");

        if (verticleInput != 0)
        {
            transform.position += transform.forward * movementSpeed * verticleInput * Time.deltaTime;
        }

        if(horizontalInput != 0)
        {
            transform.Rotate(Vector3.up * rotationSpeed * horizontalInput);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Camera mapCamera;

    public Transform player;
    public int camerazoom;

	// Use this for initialization
	void Start ()
    {
        mapCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(player.position.x, transform.position.y,player.position.z);
        transform.rotation = Quaternion.Euler(new Vector3(90f, 0, player.eulerAngles.y));

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            mapCamera.fieldOfView -= camerazoom * Input.GetAxis("Mouse ScrollWheel");
        }

	}
}

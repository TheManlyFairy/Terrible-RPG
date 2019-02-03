using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldMap : MonoBehaviour {

    public RawImage worldMapImage;
    
    void Start()
    {
        worldMapImage = GetComponent<RawImage>();
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            worldMapImage.enabled = true;
        }
        else
        worldMapImage.enabled = false;

    }
}

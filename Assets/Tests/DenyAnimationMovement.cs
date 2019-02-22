using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenyAnimationMovement : MonoBehaviour {

    float preAnimationX, preAnimationZ;
	// Use this for initialization
	void Start () {
        preAnimationX = transform.localPosition.x;
        preAnimationZ = transform.localPosition.z;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.localPosition = new Vector3(preAnimationX, transform.localPosition.y, preAnimationZ);
	}
}

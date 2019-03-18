using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPreventObscure : MonoBehaviour
{

    Ray ray;
    RaycastHit lastHitObject;
    [Range(0, 1)]
    public float transperancyPower;

    void Start()
    {
        ray = new Ray(transform.position, transform.forward * Mathf.Infinity);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * Mathf.Infinity, Color.red);
        RaycastHit hit;
        //Debug.Log("Casting...");
        
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider)
            {
                //Debug.Log("Hit " + hit.collider.name);
                if (!hit.collider.GetComponent<PartyManager>())
                {
                    //Debug.Log("Object is not a party Manager");
                    hit.collider.GetComponent<Renderer>().material.color = new Color(1, 1, 1, transperancyPower);
                    lastHitObject = hit;
                }
                else if (lastHitObject.collider)
                {
                    //Debug.Log("Object is a party Manager");
                    lastHitObject.collider.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                }
            }
        }
        else
        {
            //Debug.Log("Hit nothing");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VIDE_Data;
public class VIDECharacterInteraction : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TryInteract();
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
    }
    void TryInteract()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, 5))
        {
            VIDE_Assign VDAssign = hit.collider.GetComponent<VIDE_Assign>();
            if (VDAssign != null)
            {
                VIDEDialogueManager.Interact(VDAssign);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour {

    public GameObject left, center, right;

    void changeColor(GameObject g)
    {
        if (g.GetComponent<Renderer>().material.color == Color.white)
            g.GetComponent<Renderer>().material.color = Color.red;
        else
            g.GetComponent<Renderer>().material.color = Color.white;
    }
    public void OnLeftClick()
    {
        changeColor(left);
        //changeColor(right);
    }
    public void OnCenterClick()
    {
        changeColor(left);
        changeColor(right);
    }
    public void OnRightClick()
    {
        changeColor(center);
        changeColor(right);
    }
}

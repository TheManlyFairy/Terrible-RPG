using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuCameraTest : MonoBehaviour
{

    Vector3 startPos;
    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //FocusPosition();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Debug.Log("Mouse position: " + Camera.main.ScreenPointToRay(Input.mousePosition));

            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(transform.position, transform.forward * 100, Color.blue, 2);

                Debug.Log("Hit: " + hit.collider.name + ", at: " + hit.point);
                //StartCoroutine(MoveToFocus(hit.point));

                do
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.1f);
                }
                while (transform.position != targetPos);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        StopCoroutine(MoveToFocus(targetPos));

        transform.position = Vector3.MoveTowards(transform.position, startPos, 0.3f);
    }

    void FocusPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.Log("Mouse position: " + Camera.main.ScreenPointToRay(Input.mousePosition));

        if(Physics.Raycast(ray, out hit, 100.0f))
        {
            Debug.DrawRay(transform.position, transform.forward * 100, Color.blue,2);

            Debug.Log("Hit: " + hit.collider.name + ", at: " + hit.point);
            StartCoroutine(MoveToFocus(hit.point));
        }
    }

    IEnumerator MoveToFocus(Vector3 target)
    {
        targetPos = target;
        do
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.5f);
        }
        while (Vector3.Distance(transform.position, targetPos) > 1);
        yield return null;
    }
}

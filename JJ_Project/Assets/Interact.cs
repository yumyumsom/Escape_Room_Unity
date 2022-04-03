using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float interactDiastance = 2f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward); RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactDiastance))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    hit.collider.transform.parent.GetComponent<DoorScript>().ChangeDoorState();
                }
            }
        }
    }
}


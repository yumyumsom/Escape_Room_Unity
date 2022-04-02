using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorScript : MonoBehaviour
{
   
    public bool open = false;
    public float doorOpenAngle = 150f;
    public float doorCloseAngle = 90f;
    public float smoot = 2f;
    public void ChangeDoorState() { open = !open; }

   
    void Update()
    {

        if (open)
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoot * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Lib");
            }
         
        }
        else
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoot * Time.deltaTime);
        }
         
 
    }
}

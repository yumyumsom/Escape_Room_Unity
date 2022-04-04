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

    private float DelayTime = 5f;
    private float TickTime;
    
    public void ChangeDoorState() { open = !open; }
    void Update()
    {
        if (open)
        {
            TickTime += Time.deltaTime;
            Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoot * Time.deltaTime);

            if (TickTime >= DelayTime)
            {
                SceneManager.LoadScene("Library");
            }
        
        }
        else
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoot * Time.deltaTime);
        }
    }

}

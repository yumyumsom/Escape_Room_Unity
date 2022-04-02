using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 2.0f;
    public Rigidbody body;

    void Start()
    {
        //body = GetComponent<Rigidbody>();
        // 중력해제
       //body.useGravity = false;
    }

  
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(h, 0, v);

        if (!(h == 0 && v == 0))
        {
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            
                angle = angle * rotationSpeed * Time.deltaTime;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
            
        }
        //transform.Translate(direction * moveSpeed * Time.deltaTime);
        //transform.position += direction * moveSpeed * Time.deltaTime;
    }

}

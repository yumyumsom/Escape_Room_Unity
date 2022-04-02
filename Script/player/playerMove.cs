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
        body = GetComponent<Rigidbody>();
        // 중력해제
       body.useGravity = false;
    }

  
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float hSpeed = h * moveSpeed;
        float vSpeed = v * moveSpeed;

        Vector3 newdirection = new Vector3(hSpeed, 0, vSpeed);
        body.velocity = newdirection;

       /* if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
        Vector3 direction = new Vector3(h, 0, v).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        }*/
    }

   /* void FixedUpdate()
    {
        
    }*/
}

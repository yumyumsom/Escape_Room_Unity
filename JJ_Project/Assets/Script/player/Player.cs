using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public float Speed = 10.0f;
    public float rotateSpeed = 10.0f; // 회전 속도 
    float h, v;

    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v); // new Vector3(h, 0, v)가 자주 쓰이게 되었으므로 dir이라는 변수에 넣고 향후 편하게 사용할 수 있게 함 
        // 바라보는 방향으로 회전 후 다시 정면을 바라보는 현상을 막기 위해 설정 
        if (!(h == 0 && v == 0))
        { // 이동과 회전을 함께 처리 
            transform.position += dir * Speed * Time.deltaTime;
            // 회전하는 부분. Point 1. 
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
        }
    }
   
    }

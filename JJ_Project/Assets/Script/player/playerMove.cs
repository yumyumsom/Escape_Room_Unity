using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerMove : MonoBehaviour
{
    private float moveSpeed = 3.5f;
    private float rotationSpeed = 100f;
    private float hRotationSpeed = 100f;  // 좌우 회전 속도
    void Start()
    {

    }
    void FixedUpdate()
    {
        float t = Time.deltaTime;
        float h = Input.GetAxis("Horizontal") * rotationSpeed * t;// 키보드 입력 감지(좌 우 일때만 회전)
        Quaternion hRot = Quaternion.AngleAxis(h, Vector3.up); // 회전 변위 생성
        transform.rotation = hRot * transform.rotation;
        Vector3 move =
           transform.forward * Input.GetAxis("Vertical") +
           transform.right * Input.GetAxis("Horizontal");
        // 이동량을 좌표에 반영
        transform.position += move * moveSpeed * t;
    }
}

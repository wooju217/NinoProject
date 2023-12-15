using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float Speed = 5;
    public float Sensivity;
    public Camera Cam;

    private float xRotate;
    

    private void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        float boostSpeed = 0;
        if (Input.GetKey(KeyCode.LeftShift))
            boostSpeed = 8;

        float y = 0;
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Space))
            y = 1;
        else if (Input.GetKey(KeyCode.Q))
            y = -1;

        Cam.fieldOfView = Input.GetKey(KeyCode.C) ? 35 : 70;
        
        transform.Translate(new Vector3(h, y, v) * (Speed + boostSpeed) * Time.deltaTime, Space.Self);
        
        
        float yRotateSize = Input.GetAxis("Mouse X") * Sensivity;
        // 현재 y축 회전값에 더한 새로운 회전각도 계산
        float yRotate = transform.eulerAngles.y + yRotateSize;

        // 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
        float xRotateSize = -Input.GetAxis("Mouse Y") * Sensivity;
        // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
        // Clamp 는 값의 범위를 제한하는 함수
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);
    
        // 카메라 회전량을 카메라에 반영(X, Y축만 회전)
        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
    }
}

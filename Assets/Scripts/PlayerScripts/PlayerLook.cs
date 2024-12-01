using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float yRotation = 0f;

    public float xSensitivity = 50f;
    public float ySensitivity = 50f;


    public void ProcessLook(UnityEngine.Vector2 input) {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= mouseY * Time.deltaTime * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation = UnityEngine.Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(UnityEngine.Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}

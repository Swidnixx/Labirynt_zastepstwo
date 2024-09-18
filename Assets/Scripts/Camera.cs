using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float speed = 100;
    private float rotX;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        mouseX *= Time.deltaTime * speed;
        transform.parent.Rotate(new Vector3(0, mouseX, 0));

        mouseY *= Time.deltaTime * speed;
        rotX += -mouseY;
        rotX = Mathf.Clamp(rotX, -75, 55);
        transform.localRotation = Quaternion.Euler(Vector3.right * rotX);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] float sensitivity;
    [SerializeField] float xRotateion;
    [SerializeField] Transform orientation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity;

        xRotateion -= mouseY;
        xRotateion = Mathf.Clamp(xRotateion, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotateion, 0, 0);
        orientation.Rotate(Vector3.up * mouseX);
    }
}

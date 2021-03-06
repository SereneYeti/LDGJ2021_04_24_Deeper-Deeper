using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 500f;
    public Transform playerBody;

    float xRotatation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotatation -= inputY;
        xRotatation = Mathf.Clamp(xRotatation, -90f, 45f);

        transform.localRotation = Quaternion.Euler(xRotatation * 2, 0, 0);
        playerBody.Rotate(Vector3.up * inputX * Time.deltaTime * 50);
    }
}

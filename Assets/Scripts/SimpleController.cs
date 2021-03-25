using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController : MonoBehaviour
{
    [SerializeField] private float sencivity;
    private float angleY, angleX;
    private CharacterController controllor;
    [SerializeField] private float speed;
    [SerializeField] private float View;

    private void Start()
    {
        controllor = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * sencivity;
        var mouseY = Input.GetAxis("Mouse Y") * sencivity;

        angleY += mouseX;
        angleX -= mouseY;

        angleX = Mathf.Clamp(angleX, -View, View);

        gameObject.transform.localRotation = Quaternion.Euler(0, angleY, 0);
        transform.GetChild(0).localRotation = Quaternion.Euler(angleX, 0, 0);
 
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * X + transform.forward * Z;
        if (!Input.GetKey(KeyCode.LeftShift))
            controllor.Move(move * speed * Time.deltaTime);
        else
            controllor.Move(move * speed * Time.deltaTime * 1.5f);
    }
}

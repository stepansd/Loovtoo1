using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;

    private Transform parent;   

    void Start()
    {
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;//paneb meie kursor keskele
    }

    
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        parent.Rotate(Vector3.up, mouseX);
    }
}

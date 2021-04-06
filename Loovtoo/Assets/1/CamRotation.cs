using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotation : MonoBehaviour
{
    public bool LookAtPlayer = false;
    public bool RotateAround = true;
    public float RotateSpeed = 5.0f;
    public Vector3 Cam;
    public Transform PlayerTransform;
    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Cam = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (RotateAround)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotateSpeed, Vector3.up);
            Cam = camTurnAngle * Cam;
        }

        Vector3 newPos = PlayerTransform.position + Cam;
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if(LookAtPlayer || RotateAround)
        {
            transform.LookAt(PlayerTransform);
        }
    }
}

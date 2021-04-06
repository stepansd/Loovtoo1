using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamOrbit : MonoBehaviour
{
    private Transform _XForm_Camera;
    private Transform _XForm_Parent;

    private Vector3 _LocalRotation;// et arvutada rotation
    private float _CameraDistance = 10f;

    public float MouseSensitivity = 4f;
    public float ScrollSensitivity = 2f;
    public float OrbitDampening = 10f;
    public float ScrillSpeed = 6f;

    public bool CameraDisabled = false;

    // Start is called before the first frame update
    void Start()
    {
        this._XForm_Camera = this.transform;
        this._XForm_Parent = this.transform.parent;
    }

    // Update is called once per frame
    void LateUpdate()
    {
       
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            CameraDisabled = !CameraDisabled;// if true teeb false ja if false teeb true
        }

        if (!CameraDisabled)
        {
            if(Input.GetAxis("Mouse X") != 0 || (Input.GetAxis("Mouse Y") != 0))
            {
                _LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                _LocalRotation.y -= Input.GetAxis("Mouse Y") * MouseSensitivity;

                _LocalRotation.y = Mathf.Clamp(_LocalRotation.y, 0, 90);// ei anna kaamerale tagurpidi saama 
            }

            if (Input.GetAxis("Mouse ScrollWheel")!= 0f)
            {
                float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitivity;

                ScrollAmount *= (this._CameraDistance * 0.3f);//kui kaamera on kaugel siis scroll on kiir, kui me oleme lahedal siis on aeglane

                this._CameraDistance += ScrollAmount * -1f;//
                this._CameraDistance = Mathf.Clamp(this._CameraDistance, 1.5f, 100f);// ei anna tulla lahemale kui 1.5m / kaugemale kui 100m
            }
        }

        Quaternion QT = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);
        this._XForm_Parent.rotation = Quaternion.Lerp(this._XForm_Parent.rotation, QT, Time.deltaTime * OrbitDampening);


        if (this._XForm_Camera.localPosition.z != this._CameraDistance* -1f)
        {
            this._XForm_Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this._XForm_Camera.localPosition.z, this._CameraDistance * -1f, Time.deltaTime * ScrollSensitivity));
        }
    }
}

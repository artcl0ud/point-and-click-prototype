using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraRig))]
public class MousePOV : MonoBehaviour
{
    public float xSensitivity = 2f;
    public float ySensitivity = 2f;
    public bool clampVerticalRotation = true;
    public float minimumX = -90f;
    public float minimumY = 90f;
    public bool smooth;
    public float smoothTime = 5f;

    private Quaternion yAxis;
    private Quaternion xAxis;
    private CameraRig rig;

    void Start()
    {
        rig = GetComponent<CameraRig>();
    }

    void Update() 
    {
        if(Input.GetMouseButtonDown(0) && (Input.GetAxis("Mouse X") != 0 || (Input.GetAxis("Mouse Y") != 0)))
        {
            yAxis = rig.y_Axis.localRotation;
            xAxis = rig.x_Axis.localRotation;
            LookRotation();
        }
    }

    public void LookRotation()
    {
        float yRot = Input.GetAxis("Mouse X") * xSensitivity;
        float xRot = Input.GetAxis("Mouse Y") * ySensitivity;

        yAxis *= Quaternion.Euler (0f, yRot, 0f);
        xAxis *= Quaternion.Euler (-xRot, 0f, 0f);

        if(clampVerticalRotation)
        {
            xAxis = ClampRotationAroundAxis (xAxis);
        }

        if(smooth)
        {
            rig.y_Axis.localRotation = Quaternion.Slerp(rig.y_Axis.localRotation, yAxis, smoothTime * Time.deltaTime);
            rig.x_Axis.localRotation = Quaternion.Slerp(rig.x_Axis.localRotation, xAxis, smoothTime * Time.deltaTime);
        }
    }
}

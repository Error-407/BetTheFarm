using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    //Rotation Sensitivity
    public float RotationSensitivity = 35.0f;
    public float minAngle = -45.0f;
    public float maxAngle = 45.0f;

    //Rotation Value
    float yRotate = 0.0f;

    // Update is called once per frame
    public void Senstivity(Slider slider)
    {
        RotationSensitivity = slider.value * 20;
    }

    void Update()
    {

        //Rotate Y view
        yRotate += Input.GetAxis("Mouse Y") * RotationSensitivity * Time.deltaTime * -1;
        yRotate = Mathf.Clamp(yRotate, minAngle, maxAngle);
        transform.eulerAngles = new Vector3(yRotate, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform CameraRotation;
    private float Mouse_X;
    private float Mouse_Y;
    public float MouseSensitive = 100f;
    public float xRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //視角轉向
        Mouse_X = Input.GetAxis("Mouse X") * MouseSensitive * Time.deltaTime;
        Mouse_Y = Input.GetAxis("Mouse Y") * MouseSensitive * Time.deltaTime;
        xRotation -= Mouse_Y;
        xRotation = Mathf.Clamp(xRotation, -65f, 40f);
        CameraRotation.Rotate(Vector3.up * Mouse_X);
        this.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}

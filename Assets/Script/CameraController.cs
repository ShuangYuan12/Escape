using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public Transform CameraRotation;
    private float Mouse_X;
    private float Mouse_Y;
    public float MouseSensitive = 100f;
    public float xRotation;
    public GameObject conversation;
    bool isFind = false;

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

        if(isFind == true && CameraRotation.eulerAngles.y >= 175 && CameraRotation.eulerAngles.y <= 185){
            transform.DOLocalRotate(new Vector3(1.2f, 0, 0), 0.2f);
            conversation.GetComponent<ConversationController>().goConversation(5);
            isFind = false;
            GameManager.moveEnable(false, false);
        }
    }

    public void cameraShake(){
        transform.DOShakePosition(0.6f, 0.1f);
    }

    public void camerarot(){
        isFind = true;
    }

    public void phoneGameCamRot(){
        transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
    }
}

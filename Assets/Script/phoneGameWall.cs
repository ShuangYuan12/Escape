using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phoneGameWall : MonoBehaviour
{
    public GameObject cam;
    bool istrigger = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.tag == "Player"){
            cam.GetComponent<CameraController>().phoneGameCamRot();
            GameManager.moveEnable(false, false);
            transform.parent.GetComponent<phoneGameController>().phoneRing();
            istrigger = false;
        }
    }
}

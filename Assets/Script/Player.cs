using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 3f;
    //public float JumpSpeed = 5f;
    //public Rigidbody rig;
    public CharacterController cc;
    public GameObject mainCamera;
    public GameObject conversation;
    public GameObject gate3to4;
    public RawImage mask;
    private float horizontal;
    private float vertical;
    //private bool isJump = true;
    Vector3 Player_Move;
    Floor floor = Floor.F3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Player_Move = (transform.forward * vertical + transform.right * horizontal) * MoveSpeed;
        cc.SimpleMove(Player_Move);

        // if (Input.GetAxis("Jump") == 1 && isJump == true)
        // {
        //     rig.velocity = Vector3.up * JumpSpeed;
        //     isJump = false;
        // }

        switch (floor)
        {
            case Floor.F3:
                if (transform.position.y > 8.9f && transform.position.z > -5f)
                {
                    mask
                        .DOFade(1, 0.5f)
                        .OnComplete(() =>
                        {
                            GameManager.moveEnable(false, false);
                            gameObject.GetComponent<CharacterController>().enabled = false;
                            transform.SetPositionAndRotation(new Vector3(13.887f, 8.914f, -8.371f), Quaternion.Euler(0, -90, 0));
                            mainCamera.transform.localEulerAngles = new Vector3(0, 0, 0);
                            gameObject.GetComponent<CharacterController>().enabled = true;
                            gate3to4.SetActive(true);
                            conversation.GetComponent<ConversationController>().goConversationGu(1);
                        });
                    floor = Floor.F4;
                }
                break;
            // case Floor.F4:
            //     if (transform.position.y > 11.9f && transform.position.z > -4.4f)
            //     {
            //         mask
            //             .DOFade(1, 0.5f)
            //             .OnComplete(() => {
            //                 GameManager.moveEnable(false, false);
            //                 gameObject.GetComponent<CharacterController>().enabled = false;
            //                 transform.SetPositionAndRotation(new Vector3(-9.15f, 11.913f, -3.675f), Quaternion.Euler(0, 180, 0));
            //                 mainCamera.transform.localEulerAngles = new Vector3(0, 0, 0);
            //                 gameObject.GetComponent<CharacterController>().enabled = true;
            //                 mask.DOFade(0, 0.5f).OnComplete(() => conversation.GetComponent<ConversationController>().goConversationHe(1));
            //             });

            //         floor = Floor.F5;
            //     }
            //     break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {

        //rig.velocity += Player_Move * Time.deltaTime;

    }

    // private void OnCollisionEnter(Collision col){
    //     isJump = true;
    // }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "invisibleGate")
        {
            Debug.Log("hit");
            conversation.GetComponent<ConversationController>().gateC();
        }
    }

    public void moveToTop()
    {
        gameObject.GetComponent<CharacterController>().enabled = false;
        transform.SetPositionAndRotation(new Vector3(-9.15f, 11.913f, -3.675f), Quaternion.Euler(0, 180, 0));
        mainCamera.transform.localEulerAngles = new Vector3(0, 0, 0);
        gameObject.GetComponent<CharacterController>().enabled = true;
        mask.DOFade(0, 0.5f).OnComplete(() => conversation.GetComponent<ConversationController>().goConversationHe(1));
    }
}

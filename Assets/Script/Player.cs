using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float JumpSpeed = 5f;
    public Rigidbody rig;
    private float horizontal;
    private float vertical;
    private bool isJump = true;
    Vector3 Player_Move;

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

        if (Input.GetAxis("Jump") == 1 && isJump == true)
        {
            rig.velocity = Vector3.up * JumpSpeed;
            isJump = false;
        }
    }

    private void FixedUpdate() {

        rig.velocity += Player_Move * Time.deltaTime;

    }

    private void OnCollisionEnter(Collision col){
        isJump = true;
    }
}

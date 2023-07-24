using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheetah : MonoBehaviour
{
    private PlayerController pc;

    void Awake()
    {
        pc = GetComponent<PlayerController>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift)){
            pc.moveSpeed = 1f;
            pc.jumpForce = 3f;
        }else if(Input.GetKeyUp(KeyCode.LeftShift)){
            pc.moveSpeed = 1f;
            pc.jumpForce = 5f;
        }
    }
}

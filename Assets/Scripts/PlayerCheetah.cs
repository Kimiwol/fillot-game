using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheetah : MonoBehaviour
{
    private PlayerController pc;
    private float moveSpeedInitialValue;
    private float jumpForceInitialValue; 
    void Awake(){
        pc = GetComponent<PlayerController>();
        moveSpeedInitialValue = pc.moveSpeed;
        jumpForceInitialValue = pc.jumpForce;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift)){
            pc.moveSpeed = (float)(moveSpeedInitialValue*1.5);
            pc.jumpForce = (float)(jumpForceInitialValue*1.5);
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift)){
            pc.moveSpeed = moveSpeedInitialValue;
            pc.jumpForce = jumpForceInitialValue;
        }
    }
}

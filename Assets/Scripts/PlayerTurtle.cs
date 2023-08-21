using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurtle : MonoBehaviour
{
    private PlayerController pc;
    private float moveSpeedInitialValue;
    private float jumpForceInitialValue;
     
    void Awake()
    {
        pc = GetComponent<PlayerController>();
        moveSpeedInitialValue = pc.moveSpeed;
        jumpForceInitialValue = pc.jumpForce;
    }

    void Update()
    {
        /*if(pc.isWater)
        {
            
        }
        else{
            pc.moveSpeed = (float)(moveSpeedInitialValue*0.5);
            pc.jumpForce = (float)(jumpForceInitialValue*0.5);
        }*/
    }
}

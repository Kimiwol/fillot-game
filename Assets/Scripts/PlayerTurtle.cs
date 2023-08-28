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
        if(pc.isWater)
        {
            pc.moveSpeed = (float)(moveSpeedInitialValue*1.5);
            pc.jumpForce = (float)(jumpForceInitialValue*0); //최종은 점프 불가능하게 수정할 예정
            
        }
        else{
            pc.moveSpeed = (float)(moveSpeedInitialValue*0.5);
            pc.jumpForce = (float)(jumpForceInitialValue*0.5);
        }
    }
}

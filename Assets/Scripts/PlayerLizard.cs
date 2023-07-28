using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLizard : MonoBehaviour
{

    private PlayerController pc;

    public bool isWallJump = false;

    private void Awake()
    {
        pc = GetComponent<PlayerController>();
    }

    private void Update()
    {

        if (pc.isWall)
        {
            MoveByKeyInput();
            if (Input.GetKeyDown(KeyCode.Space) && !isWallJump) 
            {
            isWallJump = true;
            Invoke("FreezeX", 0.3f);
            Debug.Log("jump!");
            pc.rb.velocity = new Vector2(-pc.isRight*pc.jumpForce, 0.9f*pc.jumpForce);
            }
        }

        // 벽에 닿았을 때 애니메이션 변경
        // anim.SetBool("IsSling", isOnWall);
    }
    
    void FreezeX()
    {
        isWallJump = false;
    }

    void MoveByKeyInput()
    {
        float horizontalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0f, horizontalInput, 0f) * pc.moveSpeed*0.3f;
        if(!pc.isGround || horizontalInput>0){
            transform.position += movement;
        }
    }
}
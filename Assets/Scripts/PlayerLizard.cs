using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLizard : MonoBehaviour
{

    private PlayerController pc;
    private PlayerSetter ps;

    public bool isWallJump = false;
    
    private void Awake()
    {
        pc = GetComponent<PlayerController>();
        ps = GetComponent<PlayerSetter>();
    }

    private void Update()
    {

        if (pc.isWall)
        {
            // 중력 0으로
            pc.rb.gravityScale = 0f;

            MoveByKeyInput();
            if (Input.GetKeyDown(KeyCode.Space) && !isWallJump) 
            {
            isWallJump = true;
            Invoke("FreezeX", 0.3f);
            Debug.Log("jump!");
            pc.rb.velocity = new Vector2(-pc.isRight*pc.jumpForce, 0.9f*pc.jumpForce);
            }
        }
        
        if (!(pc.isWall))
        {
            // 원래 중력으로
            pc.rb.gravityScale = ps.GetGravityScaleInitialValue();
        }

        // 벽에 닿았을 때 애니메이션 변경
        // anim.SetBool("IsSling", isOnWall);
    }
    
    void FreezeX()
    {
        isWallJump = false;
        pc.rb.gravityScale = ps.GetGravityScaleInitialValue();
    }

    void MoveByKeyInput()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0f, verticalInput, 0f) * pc.moveSpeed*0.3f;
        if(!pc.isGround || verticalInput>0){
            transform.position += movement;
        }
    }
}

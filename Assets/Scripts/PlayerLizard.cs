using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLizard : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D rb;
    private PlayerController pc;

    [SerializeField]
    public bool isOnWall;
    public bool isWallJump;
    public float isRight = 1; // 바라보는 방향 1 = 오른쪽, -1 = 왼쪽

    public Transform wallCheck;
    public float WallCheckDistance;
    public LayerMask WallLayer;

    private void Awake()
    {
        pc = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {


        // 캐릭터가 기본적으로 오른쪽을 바라보기 때문에 방향에 Vector2.right을 넣어줌
        // 캐릭터가 바라보는 방향에 따라 빛을 쏘는 방향이 달라질 수 있게 isRight을 곱해줌
        // 캐릭터가 왼쪽을 바라보면 isRight이 -1이 되어 빛이 왼쪽을 비추게 됨
        isOnWall = Physics2D.Raycast(wallCheck.position, Vector2.right*isRight, WallCheckDistance, WallLayer);

        if (isOnWall)
        {
            isWallJump = false;
            MoveByKeyInput();

            if(pc.isJump && Input.GetKeyDown(KeyCode.LeftShift))
            {
                isWallJump = true;
                Invoke("FreezeX", 0.3f);                
                rb.velocity = new Vector2(-isRight*pc.jumpForce, 0.9f*pc.jumpForce);
                // 플레이어 좌우반전
                // FlipPalyer();
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
        float y = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(0, y * pc.moveSpeed);
    }


}

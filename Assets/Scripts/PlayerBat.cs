using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBat : MonoBehaviour
{
    private bool isBat;
    private PlayerController pc;
    // Start is called before the first frame update
    public Transform wallChk;
    public float wallchkDistance;
    public LayerMask w_Layer;
    bool isWall;

    private void Awake()
    {
        pc = GetComponent<PlayerController>();
        isBat = false;
    }
    
    // Update is called once per frame
    private void Update()
    {
        isWall=Physics2D.Raycast(wallChk.position, Vector2.up, wallchkDistance, w_Layer);
        Debug.DrawRay(wallChk.position, Vector2.up * wallchkDistance, Color.red);
        //�̰� ������ �Ÿ� �׸��°Ŵ� �� �ȵ�
        //���� isWall�϶��� ���� �ǵ��� ���� �ؾ߰���+�̵����϶� �¿������ �ȵǵ���
        if (Input.GetKeyDown(KeyCode.B))
        {
            isBat = !isBat;
            pc.rb.gravityScale = -pc.rb.gravityScale;
        }

        if (isBat && Input.GetKeyDown(KeyCode.Space) && !pc.isJump)
        {
            Debug.Log("Batjump");
            BatJump();
        }
    }

    private void BatJump()
    {
        pc.isJump = true;
        pc.rb.AddForce(new Vector2(0f, -pc.jumpForce), ForceMode2D.Impulse);
    }



}
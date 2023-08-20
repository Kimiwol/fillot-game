using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKingkong : MonoBehaviour
{
    private PlayerController pc;
    private int isUp = 1;
    private bool isCrack;

    // Start is called before the first frame update
    void Start()
    {
        // 크기 변경
        Vector3 originalScale = transform.localScale;
        Vector3 newScale = new Vector3(originalScale.x * 1.5f, originalScale.y * 1.5f, 1f);
        transform.localScale = newScale;

        // 무게 변경
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        rb2D.gravityScale *= 1.5f;
    }

    private void FixedUpdate() {
        MoveByKeyInput();
        Crack();
    }

    private void MoveByKeyInput()
    {
        float VerticalInput = Input.GetAxis("Vertical");

        if(VerticalInput > 0){
            isUp = 1;
        }
        if(VerticalInput < 0){
            isUp = -1;
        }
    }

    private void Crack()
    {
        Debug.DrawRay(transform.position, Vector2.right*pc.isRight*1f, Color.blue);
        Debug.DrawRay(transform.position, Vector2.up*isUp*1f, Color.blue);
        isCrack = Physics2D.Raycast(transform.position, Vector2.right*pc.isRight, 1f, LayerMask.GetMask("Wall"));
        isCrack = Physics2D.Raycast(transform.position, Vector2.up*isUp, 1f, LayerMask.GetMask("Wall"));
    }

}

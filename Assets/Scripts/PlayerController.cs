using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 9f;
    public float jumpForce = 14f;
    public Rigidbody2D rb;
    public bool isJump = true;
    public float jumpForceInitialValue;
  
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpForceInitialValue = rb.gravityScale;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJump){
            Jump();
        }
    }
    
    private void FixedUpdate() {
        MoveByKeyInput();
    }
    
    private void MoveByKeyInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
    }

    public void Jump()
    {
        isJump = true;
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }
}
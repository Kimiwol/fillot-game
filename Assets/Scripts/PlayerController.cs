using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 0.3f;
    public float jumpForce = 4f;

    public bool isJump = true;
    public bool isWall;
    public bool isGround;
    public bool isWater;
    public int isRight = 1;
  
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJump){
            Jump();
        }
    }
    
    private void FixedUpdate() {
        MoveByKeyInput();
        StopToWall();
    }
    
    private void MoveByKeyInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if(horizontalInput > 0){
            isRight = 1;
        }
        if(horizontalInput < 0){
            isRight = -1;
        }
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed;
        
        if(!isWall){
            transform.position += movement;
        }
        
        
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

        if (collision.gameObject.CompareTag("Water"))
        {
            isWater = true;
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

    private void StopToWall(){
        Debug.DrawRay(transform.position, Vector2.right*isRight*1f, Color.red);
        isWall = Physics2D.Raycast(transform.position, Vector2.right*isRight, 1f, LayerMask.GetMask("Wall"));
        isGround = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Wall"));
    }

    private void Water(){
        //물을 만나면 isWater=true;
    }
}   
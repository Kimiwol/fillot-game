using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 1f;
    public float jumpForce = 3f;

    [SerializeField]
    public bool isJump = true;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        Vector2 movement = new Vector2(horizontalInput, 0f) * moveSpeed;
        transform.Translate(movement);

    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space) && !isJump){   
            Debug.Log("input");
            Jump();
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
    }
}

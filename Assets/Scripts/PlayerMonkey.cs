using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonkey : MonoBehaviour
{
    [SerializeField]
    private bool isMonkeyJump = true;
    private PlayerController pc;
    Vector2 collisionObject;

    private void Start()
    {
        pc = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && pc.isJump && !isMonkeyJump)
        {
            isMonkeyJump = true;

        }
        if  (Input.GetKeyUp(KeyCode.Space)){
            
            pc.rb.gravityScale = pc.jumpForceInitialValue;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MonkeyJump"))
        {
            isMonkeyJump = false;
            collisionObject = collision.gameObject.GetComponent<Transform>().position;
        } 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MonkeyJump"))
        {
            isMonkeyJump = true;
        } 
    }
}

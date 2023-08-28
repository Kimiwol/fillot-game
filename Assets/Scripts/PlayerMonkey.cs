using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonkey : MonoBehaviour
{
    private float monkeyJumpRadius = 2.0f; 
    private float monkeyJumpSpeed = 2.0f;
    [SerializeField]
    private bool isMonkeyJump = true;
    private PlayerController pc;
    Vector2 monkeyJump;
    Vector2 monkeyJumpCenter;

    private void Awake()
    {
        pc = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isMonkeyJump)
        {
            pc.rb.gravityScale = 0f;
            isMonkeyJump = true;

        }
        if  (Input.GetKeyUp(KeyCode.Space)){
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MonkeyJump"))
        {
            isMonkeyJump = false;
            monkeyJumpCenter = collision.gameObject.GetComponent<Transform>().position;
            Debug.Log(monkeyJumpCenter);
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
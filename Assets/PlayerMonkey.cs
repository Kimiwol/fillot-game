using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonkey : MonoBehaviour
{
    [SerializeField]
    private bool isMonkeyJump = true;
    private PlayerController pc;

    private void Start()
    {
        pc = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && pc.isJump && !isMonkeyJump)
        {
            isMonkeyJump = true;
            pc.rb.gravityScale = 0f;
            //Vector2 monkeyToFixture = new Vector2(horizontalInput, 0f);
            //pc.rb.AddForce();
        }
        if  (Input.GetKeyUp(KeyCode.Space)){
            pc.rb.gravityScale = 1f;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MonkeyJump"))
        {
            isMonkeyJump = false;
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

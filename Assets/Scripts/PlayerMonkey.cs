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
<<<<<<< HEAD
    Vector2 monkeyJumpCenter;
=======
    Vector2 collisionObject;
>>>>>>> parent of fff2d1f (타일맵 수정)

    private void Start()
    {
        pc = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isMonkeyJump)
        {
<<<<<<< HEAD
            pc.rb.gravityScale = 0f;
            StartCoroutine(MonkeyJump());
=======
            isMonkeyJump = true;

>>>>>>> parent of fff2d1f (타일맵 수정)
        }
        if  (Input.GetKeyUp(KeyCode.Space)){
            pc.rb.gravityScale = pc.jumpForceInitialValue;
        }
        
    }
    private IEnumerator MonkeyJump()
    {
        float elapsedTime = 0f;
        Vector2 initialPosition = transform.position;
        Vector2 targetPosition = monkeyJumpCenter + new Vector2(Mathf.Cos(monkeyJumpSpeed), Mathf.Sin(monkeyJumpSpeed)) * monkeyJumpRadius;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector2.Lerp(initialPosition, targetPosition, elapsedTime);
            yield return null;
        }
        transform.position = targetPosition;
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
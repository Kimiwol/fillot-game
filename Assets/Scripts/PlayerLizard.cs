using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLizard : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D rb;
    private PlayerController pc;

    [SerializeField]
    public bool isOnWall = false;

    private void Awake()
    {
        pc = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isOnWall){
            MoveByKeyInput();
        }
    }

    void MoveByKeyInput()
    {
        float y = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(0, y * pc.moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isOnWall = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isOnWall = false;
        }
    }
}
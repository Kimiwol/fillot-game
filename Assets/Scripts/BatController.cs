using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    private bool isBat = false;
    private PlayerController pc;
    // Start is called before the first frame update

    private void Awake()
    {
        pc = GetComponent<PlayerController>();
    }


    private void Start()
    {
        Debug.Log("batStart");
    }

    // Update is called once per frame
    private void Update()
    {
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
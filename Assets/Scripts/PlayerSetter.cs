using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetter : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        rb.gravityScale = 3f;
        rb.mass = 0.3f;
        rb.freezeRotation = true;
    }

}
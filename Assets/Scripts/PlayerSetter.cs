using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetter : MonoBehaviour
{
    private Rigidbody2D rb;
    private float gravityScaleInitialValue = 3f;
    private float massScaleInitialValue = 0.3f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        rb.gravityScale = gravityScaleInitialValue;
        rb.mass = massScaleInitialValue;
        rb.freezeRotation = true;
    }
    public float GetGravityScaleInitialValue(){
        return gravityScaleInitialValue;
    }
    public float GetMassScaleInitialValue(){
        return massScaleInitialValue;
    }
}
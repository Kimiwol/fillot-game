using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKingkong : MonoBehaviour
{
    private PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        // 크기 변경
        Vector3 originalScale = transform.localScale;
        Vector3 newScale = new Vector3(originalScale.x * 2f, originalScale.y * 2f, 1f);
        transform.localScale = newScale;

        // 무게 변경
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        rb2D.gravityScale *= 2f;
    }

}

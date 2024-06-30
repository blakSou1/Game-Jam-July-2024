using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float runSpeed = 5f;
    private Rigidbody2D rb;
    private Animator an;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
    }
    private void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        bool statusRun = Input.GetKey(KeyCode.LeftShift);
        Move(hInput, statusRun);
    }
    bool facR = true;
    private void Flip()
    {
        facR = !facR;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void Move(float input, bool run)
    {
        if(input != 0)
        {
            if(input > 0 && !facR)
                Flip();
            else if(input < 0 && facR)
                Flip();
            an.SetBool("Paste", true);
            if (!run)
            {
                an.SetBool("Run", false);
                rb.velocity = new Vector2(input * moveSpeed, rb.velocity.y);
            }
            else
            {
                an.SetBool("Run", true);
                rb.velocity = new Vector2(input * runSpeed, rb.velocity.y);
            }
        }
        else
        {
            an.SetBool("Run", false);
            an.SetBool("Paste", false);
        }
    }
}

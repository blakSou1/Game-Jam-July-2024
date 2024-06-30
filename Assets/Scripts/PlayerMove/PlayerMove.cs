using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  PlayerMovement : MonoBehaviour  
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
    private void Flip()
    {
        fac = !fac;
        Vector3 the = transform.localScale;
        the.x *= -1;
        transform.localScale = the;
    }
    bool fac = true;
    private void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        bool statusRun = Input.GetKey(KeyCode.LeftShift);
        Move(hInput, statusRun);
    }
    private void Move(float input, bool run)
    {
        if(input != 0)
        {
            if (fac && input < 0)
                Flip();
            else if (!fac && input > 0)
                Flip();
            an.SetBool("Point", true);
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
            an.SetBool("Point", false);
    }
}

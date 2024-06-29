using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float runSpeed = 5f;
    private Rigidbody2D rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
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
            if (!run)
                rb.velocity = new Vector2(input * moveSpeed, rb.velocity.y);
            else 
                rb.velocity = new Vector2(input * runSpeed, rb.velocity.y);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float mvtspeed;
    Rigidbody2D rb;
    public Vector2 direction;

    public bool facingRight = true;


    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        InputController();
    }


    void FixedUpdate()
    {
        Move();
    }

    void InputController()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        direction = new Vector2(moveX, moveY).normalized;



    }

    void Move()
    {
        rb.velocity = new Vector2(direction.x * mvtspeed, direction.y* mvtspeed);
    }

}

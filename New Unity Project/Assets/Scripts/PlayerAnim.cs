using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{


    Animator animator;
    PlayerMovement mvt;
    Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mvt = GetComponent<PlayerMovement>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        



    }


    void FixedUpdate()
    {
        ChangeDir();
        Anim();
    }


    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        mvt.facingRight = !mvt.facingRight;
    }

    void ChangeDir()
    {
        if((mvt.facingRight && mvt.direction.x <= -0.002) || (!mvt.facingRight && mvt.direction.x >= 0.002))
        {
            Flip();
        }
    }


    void Anim()
    {
        if(mvt.direction.x >= 0.002 || mvt.direction.y != 0 || mvt.direction.x <= -0.002)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }



}

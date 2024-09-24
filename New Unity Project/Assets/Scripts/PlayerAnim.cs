using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{


    Animator animator;
    PlayerMovement mvt;
    Transform transform;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mvt = GetComponent<PlayerMovement>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mvt.direction.x != 0 || mvt.direction.y != 0)
        {
            animator.SetBool("Move", true);
            Flip();
        }
        else 
        {
            animator.SetBool("Move", false);
        }
    }

    void Flip()
    {
        if (mvt.direction.x < 0)
        {
            transform.rotation.y = 180;
            
        }
        else 
        {
            transform.Rotation.y = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic; 
using UnityEngine;


public class PlayerAnimator : MonoBehaviour


{
    //References
    Animator am;
    PlayerMovement pm;
    SpriteRenderer sr;



    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (pm.moveDir.x > 0)
        {
            am.SetBool("Move", true);
            sr.flipX = false;
        }
        else if (pm.moveDir.x < 0)
        {
            am.SetBool("Move", true);
            sr.flipX = true;
        }
        else if (pm.moveDir.y != 0)
        {
            am.SetBool("Move", true);
        }
        else
        {
            am.SetBool("Move", false);
        }
    }
    
}

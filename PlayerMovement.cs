using System.IO;
using System.Security.AccessControl;
using System.Resources;
using System;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private bool isJumping=false;
    private float dirX;
    private enum movementState {idle,running,jumping};
    [SerializeField]private movementState state;
    [SerializeField]private float speedX=5f;
    [SerializeField]private float jumpForce=10f;
    [SerializeField]private AudioSource jumpsoundeffect;
    bool isFacingRight=true;
    void Start()
    {
        //Debug.Log("PlayerMovement script loaded");
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        sprite=GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        dirX=Input.GetAxisRaw("Horizontal") * speedX;
        if(Input.GetButtonDown("Jump"))
        {
            jumpsoundeffect.Play();
            isJumping=true;
        }
    }
    void FixedUpdate()
    {
        rb.velocity=new Vector2(dirX ,rb.velocity.y);
        if(isJumping==true && isGrounded()==true)
        {
            rb.velocity=new Vector2(rb.velocity.x,jumpForce);
            isJumping=false;
        }
        UpdateAnimationUpdate();
    }
    void UpdateAnimationUpdate()
    { 
        if(dirX!=0)
        {
            state=movementState.running;
            if(dirX>0)
                isFacingRight=true;
            else isFacingRight=false;
            anim.SetInteger("state",(int)state);//2nd one is of this script,1st one is of animator param
        }
        else
        {
            state=movementState.idle;
            anim.SetInteger("state",(int)state);
        }
        if(isFacingRight==true)
            sprite.flipX=false;
        else sprite.flipX=true;
        if(rb.velocity.y > 0.1f && isGrounded()==false)
        {
            state=movementState.jumping;
            anim.SetInteger("state",(int)state);//1st one is param of unity editor's animator's param,2nd one is local bool var
        }
        
    }
    bool isGrounded()
    {
        if(System.Math.Abs(rb.velocity.y)!=0)
            return false;
        else return true;
    }
}

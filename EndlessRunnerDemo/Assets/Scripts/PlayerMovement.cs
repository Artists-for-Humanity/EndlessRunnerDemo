using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //VARIABLES//
    private Rigidbody2D rb2d;
    private Animator anim;
    private BoxCollider2D playerCollider;
    public BoxCollider2D slideCollider;

    [Range(5,10)]
    public float jumpSpeed;
    
    [Range(1,5)]
    public float tapButtonGravity;
    [Range(2,6)]
    public float holdButtonGravity;

    [Range(1,5)]
    public float slideDuration;

    public bool canJump = true;
    public bool isSliding = true;



    public float slideGravity = 10f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //JUMPING//
        if(Input.GetKeyDown(KeyCode.Space) && canJump && !Input.GetKey(KeyCode.LeftShift))
        {
            rb2d.velocity = Vector2.up * jumpSpeed;
            canJump = false;
            anim.SetBool("isJumping",true);
        }

        if(!Input.GetKey(KeyCode.LeftShift))
        {
            if(rb2d.velocity.y < 0)
            {
                    //Increase our gravity scale
                rb2d.velocity += Vector2.up * Physics.gravity.y * (holdButtonGravity - 1) * Time.deltaTime;
            }

            //If player lets go of space while still in the air, shorter jump
            else if(rb2d.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
            {
                    rb2d.velocity += Vector2.up * Physics.gravity.y * (tapButtonGravity - 1) * Time.deltaTime;
            }

            if(rb2d.velocity.y == 0)
            {
                canJump = true;
                anim.SetBool("isJumping",false);
            }
        }
        else if(Input.GetKey(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.LeftShift))
        {
           Slide();
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("isSliding", false);
        }

                //If player is falling (velocity is negative) and is still holding space
    }

    void Slide()
    {
            rb2d.velocity += Vector2.up * Physics.gravity.y * (slideGravity - 1) * Time.deltaTime;
            isSliding = true;
            canJump = false;
            anim.SetBool("isSliding", true);
            anim.SetBool("isJumping", false);
            playerCollider.enabled = false;
            slideCollider.enabled = true;
            //StopAllCoroutines();
            StartCoroutine("StopSlide");
                        //playerCollider.size = new Vector2(1.0f, 0.5f);
            //playerCollider.offset = new Vector2(0f, -0.25f);
    }

    IEnumerator StopSlide()
    {
        yield return new WaitForSeconds(slideDuration);
        anim.SetBool("isSliding", false);
        slideCollider.enabled = false;
        playerCollider.enabled = true;
        isSliding = false;
        canJump = true;
    }
}

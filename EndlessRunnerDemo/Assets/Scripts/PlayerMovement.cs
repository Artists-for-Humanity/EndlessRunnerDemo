using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;

    [Range(5,10)]
    public float jumpSpeed;

    public bool canJump = true;

    [Range(1,5)]
    public float tapButtonGravity = 2f;
    [Range(2,6)]
    public float holdButtonGravity = 2.5f;

    public float slideGravity = 10f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //JUMPING//
        if(Input.GetKeyDown(KeyCode.Space) && canJump && !Input.GetKey(KeyCode.LeftShift))
        {
            //ForceMode2D.Impulse --> immediately adds force to RB
            rb2d.velocity = Vector2.up * jumpSpeed;
            canJump = false;
        }

        if(!Input.GetKey(KeyCode.LeftShift))
        {
            if(rb2d.velocity.y < 0)
            {
                    //Increase our gravity scale
                rb2d.velocity += Vector2.up * Physics.gravity.y * (slideGravity - 1) * Time.deltaTime;
            }

            //If player lets go of space while still in the air, shorter jump
            else if(rb2d.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
            {
                    rb2d.velocity += Vector2.up * Physics.gravity.y * (tapButtonGravity - 1) * Time.deltaTime;
            }

            if(rb2d.velocity.y == 0)
            {
                canJump = true;
            }
        }
        else if(Input.GetKey(KeyCode.LeftShift))
        {
            rb2d.velocity += Vector2.up * Physics.gravity.y * (slideGravity - 1) * Time.deltaTime;
        }

                //If player is falling (velocity is negative) and is still holding space


        //SLIDING
       // if(Input.GetKeyDown(KeyCode.LeftShift))
       // {
       //     Debug.Log("Slide");
        //    rb2d.velocity += Vector2.up * Physics.gravity.y * (slideGravity - 1) * Time.deltaTime;
       // }
    }
}

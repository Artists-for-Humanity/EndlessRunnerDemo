using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
        private Rigidbody2D rb2d;
    public float tapButtonGravity = 2f;
    public float holdButtonGravity = 2.5f;


    public bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
                rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //If player is falling (velocity is negative) and is still holding space
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
        }
    }
}

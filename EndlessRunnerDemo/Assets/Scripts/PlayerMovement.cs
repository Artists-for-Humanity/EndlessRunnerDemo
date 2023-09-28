using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //VARIABLES//
    private GameManager gm;
    private Rigidbody2D rb2d;
    public Animator anim;
    private BoxCollider2D playerCollider;
    public GameObject slideCollider;
    public GameObject attackCollider;

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
    public bool canAttack = true;
    public float slideGravity = 10f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        slideCollider.SetActive(false);
        playerCollider.enabled = true;
        canJump = true;
        isSliding = true;
        canAttack = true;
        slideGravity = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        //If GameOver == true, prevent players from moving and beating
        if(gm.gameOver == false)
        {
            //JUMPING//
            if(Input.GetKeyDown(KeyCode.Space) && canJump && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.F))
            {
                rb2d.velocity = Vector2.up * jumpSpeed;
                canJump = false;
                anim.SetBool("isJumping",true);
            }

            if(!Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.F))
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

                //If player is falling (velocity is negative) and is still holding space
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
                slideCollider.SetActive(false);
                playerCollider.enabled = true;
                isSliding = false;
                canJump = true;
            }

            if(Input.GetKey(KeyCode.F) && canAttack)
            {
                Attack();
            }
        }
       
    }

    void Slide()
    {
            slideCollider.SetActive(true);
            playerCollider.enabled = false;
            rb2d.velocity += Vector2.up * Physics.gravity.y * (slideGravity - 1) * Time.deltaTime;
            isSliding = true;
            canJump = false;
            anim.SetBool("isSliding", true);
            anim.SetBool("isJumping", false);
    }

    void Attack()
    {
        Debug.Log("ATTACK!!!!");
        anim.SetBool("isAttacking", true);
        anim.SetBool("isSliding", false);
        anim.SetBool("isJumping", false);
        attackCollider.SetActive(true);
        canAttack = false;
        StopAllCoroutines();
        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("isAttacking", false);
        yield return new WaitForSeconds(1.0f);
        Debug.Log("CAN ATTACK AGAIN");
        canAttack = true;
        attackCollider.SetActive(false);
    }
}

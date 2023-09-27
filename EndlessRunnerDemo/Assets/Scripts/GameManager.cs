using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //VARIABLES//
    public int playerHealth = 3;
    public int maxHealth = 3;

    public bool invincible = false;
    //REFERENCES//
    private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage()
    {
        Debug.Log("TAKING DAMAGE");
        if(invincible == false)
        {
            playerHealth--;
            player.anim.SetTrigger("takingDamage");
            invincible = true;
            Invoke("EndCoolDown", 0.5f);
            if(playerHealth <= 0)
            {
                Debug.Log("Game Over");
                GameOver();
            }
        }


    }

    public void GameOver()
    {

    }

    public void EndCoolDown()
    {
        invincible = false;
        player.anim.ResetTrigger("takingDamage");
    }
}

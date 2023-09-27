using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{

    //VARIABLES//
    public int playerHealth = 3;
    public int maxHealth = 3;

    public bool invincible = false;
    //REFERENCES//
    private PlayerMovement player;

    public TextMeshProUGUI gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        gameOverText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage()
    {
        Debug.Log("TAKING DAMAGE");
        if(invincible == false && playerHealth > 0)
        {
            playerHealth--;
            player.anim.SetTrigger("takingDamage");
            Invoke("EndCoolDown", 0.5f);
            if(playerHealth <= 0)
            {
                Debug.Log("Game Over");
                GameOver();
            }
            invincible = true;
        }


    }

    public void GameOver()
    {
        Debug.Log("Game Over...");
        player.anim.SetTrigger("GameOver");
        gameOverText.text = "Game Over";
    }

    public void EndCoolDown()
    {
        invincible = false;
        player.anim.ResetTrigger("takingDamage");
    }
}

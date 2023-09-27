using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{

    //VARIABLES//
    [Range (3,5)]
    public int playerHealth;
    public int score = 0;
    public bool invincible = false;
    //REFERENCES//
    private PlayerMovement player;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        gameOverText.text = "";
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
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

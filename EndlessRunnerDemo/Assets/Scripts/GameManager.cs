using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    //VARIABLES//
    [Range (3,5)]
    public int playerHealth;
    public int score = 0;
    public bool invincible = false;
    public bool gameOver = false;

    //REFERENCES//
    private PlayerMovement player;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;

    public TextMeshProUGUI healhText;
    //GameOver Panel for when players get Game Over
    public GameObject restartPanel;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        gameOverText.text = "";
        score = 0;
        restartPanel.SetActive(false);
        healhText.text = playerHealth.ToString();
        scoreText.text = "0";
        gameOver = false;
        invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        healhText.text = playerHealth.ToString();
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
                gameOver = true;
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
        restartPanel.SetActive(true);
        finalScoreText.text = score.ToString();
    }

    public void EndCoolDown()
    {
        invincible = false;
        player.anim.ResetTrigger("takingDamage");
    }

    //GAME OVER METHODS//

    //Call this method when clicking the restart button.
    //Reload the scene and try the game again.
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    //Call this method when clicking the quit button.
    //Exits out of the game and returns to the title screen.
    public void QuitGame()
    {
        Debug.Log("This method only works on builds, not in the Editor.");
        Application.Quit();
    }
}

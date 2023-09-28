using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private GameManager gm;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime,0,0);
    }

    //Call the GameManager's TakeDamage() method to deal damage to the player if the player touches an obstacle
    void OnTriggerEnter2D(Collider2D player)
    {
        if(player.gameObject.tag == "Player" && gm.invincible == false & gm.gameOver == false)
        {
            gm.TakeDamage();
        }
    }
}

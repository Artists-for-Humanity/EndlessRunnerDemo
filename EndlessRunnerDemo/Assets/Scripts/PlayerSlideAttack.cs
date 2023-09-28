using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlideAttack : MonoBehaviour
{
    // Start is called before the first frame update

    //Reference to GM 
    private GameManager gm;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("DESTROY ENEMY");
            Destroy(other.gameObject);
            gm.score += 100;
        }
    }
}

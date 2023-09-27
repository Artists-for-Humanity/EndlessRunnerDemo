using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameManager gm;
    
    public int pointValue = 10;

    private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0,0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            gm.score += pointValue;
            this.gameObject.SetActive(false);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length, startPosition;
    public GameObject camera;

    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        //Set StartPosition to the current TransformPosition.x of the BG
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Set the distance to be the current transform position 
        //Multiply it by the parallaxEffect (different for each layer)
        float dist = (camera.transform.position.x * parallaxEffect);
        transform.position = new Vector2(startPosition + dist, transform.position.y);
    }
}

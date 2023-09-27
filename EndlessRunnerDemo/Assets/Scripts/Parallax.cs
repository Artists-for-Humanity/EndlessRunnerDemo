using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length;
    private Vector2 startPosition;
    public GameObject camera;
    public bool autoScroll;
    public float parallaxEffect;
    public float targetXPosition;
    // Start is called before the first frame update
    void Start()
    {
        //Set StartPosition to the current TransformPosition.x of the BG
        startPosition = new Vector2(transform.position.x, transform.position.y);
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {

        //Store the X value of the current position of a layer in a temp variable
        float temp = (camera.transform.position.x);

        //Set the distance to be the current transform position 
        //Multiply it by the parallaxEffect (different for each layer)
        float dist = (camera.transform.position.x * parallaxEffect);
        
        float desiredXPosition = startPosition.x + dist;

        if(autoScroll)
        {
            //Pushes the BG to the left 
            desiredXPosition = transform.position.x - parallaxEffect;
        }

        transform.position = new Vector2(desiredXPosition, transform.position.y);
       //transform.position = new Vector2(startPosition + dist, transform.position.y);

        //If the value goes past the target X position (different for each layer)
        //Reset the layer's transform position to it's starting one 
        if(temp < targetXPosition)
        {
            transform.position = new Vector2(startPosition.x,startPosition.y);
        }
}
}
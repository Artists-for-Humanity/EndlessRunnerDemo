using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //OBSTACLE ARRAY OF THINGS TO SPAWN//
public List<GameObject> obstacles = new List<GameObject>(); //Can be changed in the inspector
public Vector2 spawnPosition; //Spawn Position of the ObstacleSpawner

private float obstaclePosX;
private float obstaclePosY;
//REFERENCES//
private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacles());
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstacles()
    {
        yield return new WaitForSeconds(1f);
        while(gm.gameOver == false)
        {
            for(int i = 0; i < obstacles.Count; i++)
            {
                Debug.Log("Spawn an obstacle");
                obstaclePosX = obstacles[i].transform.position.x + 20;
                obstaclePosY = obstacles[i].transform.position.y;
                spawnPosition = new Vector2(obstacles[i].transform.position.x + 20, obstacles[i].transform.position.y);
                Instantiate(obstacles[Random.Range(0, obstacles.Count)], spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
            yield return new WaitForSeconds(3f);
        }

    }
}

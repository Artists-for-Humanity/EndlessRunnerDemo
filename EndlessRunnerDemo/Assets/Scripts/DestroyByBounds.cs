using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBounds : MonoBehaviour
{
    //Destroys any object which enters its boundaries
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("DESTROY OBJECT");
        Destroy(other.gameObject);
    }
}

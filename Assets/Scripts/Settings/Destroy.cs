using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player1") 
            Destroy(gameObject);
        if (collision.gameObject.name == "Player2")
            Destroy(gameObject);
    }
}

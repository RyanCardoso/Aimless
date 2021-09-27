using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	void Start ()
    {
		
	}
	
	void Update ()
    {
        Physics2D.IgnoreLayerCollision(8, 9);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);    
    }
}
        
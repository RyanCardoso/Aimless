using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShotGun : MonoBehaviour {

	
	void Start ()
    {
    }

    private void Awake()
    {
        Physics2D.IgnoreLayerCollision(8, 8);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}

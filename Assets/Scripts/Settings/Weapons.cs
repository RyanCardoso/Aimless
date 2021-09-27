using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public GameObject Player ,Player2;
    public GameObject wpn1, wpn2, wpn3, wpn4;
    public Transform PositionSpawn;

    void Start ()
    {
        WpnSpawn();
    }

	void Update ()
    {
      
    }

    // Dado de Armas //
    
    void WpnSpawn()
    {
        int Gerador;
        Gerador = Random.Range(1,5);        
        switch (Gerador)
        {
            case 1 :
                Instantiate(wpn1, new Vector2(PositionSpawn.position.x, PositionSpawn.position.y), Quaternion.identity);
                break;
            case 2:
                Instantiate(wpn2, new Vector2(PositionSpawn.position.x, PositionSpawn.position.y), Quaternion.identity);
                break;
            case 3:
                Instantiate(wpn3, new Vector2(PositionSpawn.position.x, PositionSpawn.position.y), Quaternion.identity);
                break;
            case 4:
                Instantiate(wpn4, new Vector2(PositionSpawn.position.x, PositionSpawn.position.y), Quaternion.identity);
                break;
        }
    }

    void Arma1()
    {

    }
    
    void OnCollisionEnter2D(Collision2D Coll)
    {
        if (Coll.gameObject.tag == "Guns")
            print("dsada");
        
    }
    
}

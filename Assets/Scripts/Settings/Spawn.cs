using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject AK47, Sniper, Bazooka, Pistol;
    public Transform Spawn1, Spawn2;

    private int GunsAleatoriaP1;
    private int GunsAleatoriaP2;

    private GameObject ArmaBack, ArmaBack2;

    void Start ()
    {
        //GetComponent<Player1>();
        Shazan();
    }

    void Shazan()
    {
        GunsAleatoriaP1 = Random.Range(0, 4);
        GunsAleatoriaP2 = Random.Range(0, 4);

        //Player1
        switch (GunsAleatoriaP1)
        {
            case 0: ArmaBack = Instantiate(AK47, Spawn1.position, Quaternion.identity); break;
            case 1: ArmaBack = Instantiate(Sniper, Spawn1.position, Quaternion.identity); break;
            case 2: ArmaBack = Instantiate(Bazooka, Spawn1.position, Quaternion.identity); break;
            case 3: ArmaBack = Instantiate(Pistol, Spawn1.position, Quaternion.identity); break;
        }

        //Player2
        switch (GunsAleatoriaP2)
        {
            case 0: ArmaBack2 = Instantiate(AK47, Spawn2.position, Quaternion.identity); break;
            case 1: ArmaBack2 = Instantiate(Sniper, Spawn2.position, Quaternion.identity); break;
            case 2: ArmaBack2 = Instantiate(Bazooka, Spawn2.position, Quaternion.identity); break;
            case 3: ArmaBack2 = Instantiate(Pistol, Spawn2.position, Quaternion.identity); break;
        }
    }

    IEnumerator ResetGuns()
    {
        yield return new WaitForSeconds(5);
        Destroy(ArmaBack);
        Destroy(ArmaBack2);
        Shazan();
    }
    void Update()
    {
        if (Player1.Taka == true)
        {
            Debug.Log("entrei");
            StartCoroutine(ResetGuns());
            Player1.Taka = false;
        }

        if (Player2.Taka == true)
        {
            Debug.Log("entrei");
            StartCoroutine(ResetGuns());
            Player2.Taka = false;
        }

        //Debug.Log(GunsAleatoriaP1 + " " + GunsAleatoriaP2);



        /*if (Player1.Taka == true)
        {
            Destroy(ArmaBack);
            Destroy(ArmaBack2);

            GunsAleatoriaP1 = Random.Range(0, 4);
            GunsAleatoriaP2 = Random.Range(0, 4);
            

            //GetComponent<Player1>();

            //Player1
            switch (GunsAleatoriaP1)
            {
                case 0: ArmaBack = Instantiate(AK47, Spawn1.position, Quaternion.identity); break;
                case 1: ArmaBack = Instantiate(Sniper, Spawn1.position, Quaternion.identity); break;
                case 2: ArmaBack = Instantiate(Bazooka, Spawn1.position, Quaternion.identity); break;
                case 3: ArmaBack = Instantiate(Pistol, Spawn1.position, Quaternion.identity); break;
            }

            //Player2
            switch (GunsAleatoriaP2)
            {
                case 0: ArmaBack2 = Instantiate(AK47, Spawn2.position, Quaternion.identity); break;
                case 1: ArmaBack2 = Instantiate(Sniper, Spawn2.position, Quaternion.identity); break;
                case 2: ArmaBack2 = Instantiate(Bazooka, Spawn2.position, Quaternion.identity); break;
                case 3: ArmaBack2 = Instantiate(Pistol, Spawn2.position, Quaternion.identity); break;
            }

            Player1.Taka = false;
        }*/
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player1" && Player1.Taka = true)
    }*/
}

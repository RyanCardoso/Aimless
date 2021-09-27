using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject AK47, Sniper, Bazooka, Pistol;
    public Transform Spawn1, Spawn2;

    private int GunsAleatoriaP1;
    private int GunsAleatoriaP2;

    private int a1, a2;

    void Start()
    {
        a1 = Random.Range(0, 4);
        a2 = Random.Range(0, 4);

        switch (a1)
        {
            case 0: AK47.SetActive(true); break;
            case 1: Sniper.SetActive(true); break;
            case 2: Bazooka.SetActive(true); break;
            case 3: Pistol.SetActive(true); break;
        }

        //Player2
        switch (a2)
        {
            case 0: Instantiate(AK47, Spawn2.position, Quaternion.identity); break;
            case 1: Instantiate(Sniper, Spawn2.position, Quaternion.identity); break;
            case 2: Instantiate(Bazooka, Spawn2.position, Quaternion.identity); break;
            case 3: Instantiate(Pistol, Spawn2.position, Quaternion.identity); break;
        }

    }
    private void Shazan()
    {
        GunsAleatoriaP1 = Random.Range(0, 4);
        GunsAleatoriaP2 = Random.Range(0, 4);
       
        //Player1
        switch (GunsAleatoriaP1)
        {
            case 0: Instantiate(AK47, Spawn1.position, Quaternion.identity); break;
            case 1: Instantiate(Sniper, Spawn1.position, Quaternion.identity); break;
            case 2: Instantiate(Bazooka, Spawn1.position, Quaternion.identity); break;
            case 3: Instantiate(Pistol, Spawn1.position, Quaternion.identity); break;
        }

        //Player2
        switch (GunsAleatoriaP2)
        {
            case 0: Instantiate(AK47, Spawn2.position, Quaternion.identity); break;
            case 1: Instantiate(Sniper, Spawn2.position, Quaternion.identity); break;
            case 2: Instantiate(Bazooka, Spawn2.position, Quaternion.identity); break;
            case 3: Instantiate(Pistol, Spawn2.position, Quaternion.identity); break;
        }
    }

    IEnumerator Caplau()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    IEnumerator CaplauDnv()
    {
        yield return new WaitForSeconds(10);
        Shazan();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            this.gameObject.SetActive(false);
            StartCoroutine(CaplauDnv());
            StartCoroutine(Caplau());
        }
    }
}

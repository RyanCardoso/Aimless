using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        temArma = false;
    }

    void FixedUpdate()
    {
        Movimentacao();
        Atirar();
    }

    //Shoot
    public GameObject BulletAk;
    public Transform PosBullet;
    private bool temArma;
    private int Ammo = 30;
    public Text AmmoTxt; 
    private bool PodeAtirar = false;
    private bool CoroutineRunning = false;

    IEnumerator _PodeAtirar()
    {
        CoroutineRunning = true;
        yield return new WaitForSeconds(0.1f);
        PodeAtirar = true;
        CoroutineRunning = false;
    }

    void Atirar()
    {
        Vector3 EixosBullet;
        EixosBullet = new Vector2(PosBullet.position.x, PosBullet.position.y);

        AmmoTxt.text = Ammo.ToString();

        if (temArma == true)
        {
            if (Input.GetButton("Fire Joy"))
            {
                if (PodeAtirar && Ammo > 0)
                {
                    var Tiro = Instantiate(BulletAk, EixosBullet, Quaternion.identity);
                    Tiro.GetComponent<Rigidbody2D>().AddForce(PosBullet.up * 10000);
                    PodeAtirar = !PodeAtirar;
                    Ammo -= 1;
                }
                else
                {
                    if (!CoroutineRunning)
                        StartCoroutine(_PodeAtirar());
                }
            }
        }
    }

    //Movimentos
    public float speed;
    void Movimentacao()
    {
        //Direçoes
        float moveHorizontal = Input.GetAxis("Joy X");
        float moveVertical = Input.GetAxis("Joy Y");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Armas(collision);
        Collect(collision);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Morrer(collision);
    }

    //Pegar e Destroir
    void Collect(Collider2D collision)
    {
        if (collision.gameObject.tag == "Guns")
            Destroy(collision.gameObject);
    }

    //Guns
    public GameObject Ak47Spwan, BazookaGSpwan, KatanaSpwan, SniperSpwan;
    public GameObject PreAK47;
    public Transform PosArma;
    void Armas(Collider2D collision)
    {
        Vector3 EixosArmas;
        EixosArmas = new Vector3(PosArma.position.x, PosArma.position.y, -2);

        switch (collision.gameObject.name)
        {
            case "SpwanAK47(Clone)":
                Ammo = 30;
                //var Guns1 = Instantiate(PreAK47, EixosArmas, Quaternion.identity);
                PreAK47.SetActive(true);
                //Guns1.transform.parent = PosArma;
                break;
        }
        temArma = true;
    }

    //Morte
    public Image Life;
    public Text Wins;

    void Morrer(Collision2D collision)
    {
        if (collision.gameObject.name == "BulletAk(Clone)")
        {
            Life.fillAmount = Life.fillAmount - 0.15f;

            if (Life.fillAmount == 0)
            {
                Destroy(gameObject);
                Wins.text = "Player2 Wins";
            }
        }
    }
}

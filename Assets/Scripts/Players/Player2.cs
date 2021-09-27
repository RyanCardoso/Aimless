using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class Player2 : MonoBehaviour
{
    public string anim;
    public string SpritePlayers;
    private Rigidbody2D rb2D;

    //Movimentação do Player
    public float Velocidade;
    private Vector3 MoveEixos;


    //Armas
    public GameObject AK47, Sniper, ShotGun, Pistol;
    public Transform PosBullet, PosBullet1, PosBullet2, PosBullet3;
    private bool CheckAK, CheckPistol, CheckSniper, CheckShotGun;

    //Bullets
    public float BulletVel;
    public GameObject BulletAk, BulletSniper, BulletPistol, BulletShotGun;

    //Municao
    private int Municao = 0;
    public Text MunicaoTxt;

    //morte
    public Image Life2;

    //wins
    public Text Wins;

    //"Animacao"
    public Sprite PlyerNormal;
    public Sprite PlayerAk, PlayerSniper, PlayerPistol, PlayerShotGun;
    private SpriteRenderer AAAA;

    //Sons das Armas
    private AudioSource SoundGuns;
    public AudioClip AkSound, PistolSound, SniperSound, ShotGunSound;

    void Start()
    {
        SoundGuns = GetComponent<AudioSource>();
        rb2D = GetComponent<Rigidbody2D>();
        AAAA = GetComponent<SpriteRenderer>();
        //AAAA.sprite = PlyerNormal;
    }

    void FixedUpdate()
    {
        Move();
        Shoot();

        MunicaoTxt.text = Municao.ToString();
    }


    private void Move()
    {
        float X = Input.GetAxis("Horizontal2");
        float Y = Input.GetAxis("Vertical2");

        MoveEixos = new Vector2(X, Y);
        MoveEixos *= Velocidade;

        rb2D.AddForce(MoveEixos * Time.deltaTime);
    }


    private bool PodeAtirar = false;
    private bool CoroutineRunning = false;

    //Tempo de Recarga
    IEnumerator _PodeAtirar()
    {
        CoroutineRunning = true;

        if (CheckAK)
            yield return new WaitForSeconds(0.1f);
        else if (CheckPistol)
            yield return new WaitForSeconds(0.16f);
        else if (CheckSniper)
            yield return new WaitForSeconds(1.2f);
        else if (CheckShotGun)
            yield return new WaitForSeconds(1f);

        PodeAtirar = true;
        CoroutineRunning = false;
    }

    private void Shoot()
    {
        if (Municao == 0)
            AAAA.sprite = PlyerNormal;

        if (Input.GetKey(KeyCode.Space))
        {
            if (PodeAtirar == true && Municao >= 1)
            {
                MunicaoTxt.text = (--Municao).ToString();

                if (CheckAK)
                {
                    var Ak = Instantiate(BulletAk, PosBullet.position, Quaternion.identity);
                    Ak.GetComponent<Rigidbody2D>().AddForce(PosBullet.up * BulletVel);
                    SoundGuns.clip = AkSound;
                    SoundGuns.Play();

                    PodeAtirar = !PodeAtirar;
                }

                if (CheckSniper)
                {
                    var Sniper = Instantiate(BulletSniper, PosBullet.position, Quaternion.identity);
                    Sniper.GetComponent<Rigidbody2D>().AddForce(PosBullet.up * BulletVel);
                    SoundGuns.clip = SniperSound;
                    SoundGuns.Play();
                    PodeAtirar = !PodeAtirar;
                }

                if (CheckPistol)
                {
                    var Pistola = Instantiate(BulletPistol, PosBullet.position, Quaternion.identity);
                    Pistola.GetComponent<Rigidbody2D>().AddForce(PosBullet.up * BulletVel);
                    SoundGuns.clip = PistolSound;
                    SoundGuns.Play();
                    PodeAtirar = !PodeAtirar;
                }

                if (CheckShotGun)
                {
                    var Doze1 = Instantiate(BulletShotGun, PosBullet1.position, Quaternion.identity);
                    var Doze2 = Instantiate(BulletShotGun, PosBullet2.position, Quaternion.identity);
                    var Doze3 = Instantiate(BulletShotGun, PosBullet3.position, Quaternion.identity);

                    Doze1.GetComponent<Rigidbody2D>().AddForce(PosBullet1.up * BulletVel);
                    Doze2.GetComponent<Rigidbody2D>().AddForce(PosBullet2.up * BulletVel);
                    Doze3.GetComponent<Rigidbody2D>().AddForce(PosBullet3.up * BulletVel);

                    SoundGuns.clip = ShotGunSound;
                    SoundGuns.Play();
                    PodeAtirar = !PodeAtirar;
                }
            }
            else
                if (!CoroutineRunning)
                StartCoroutine(_PodeAtirar());
        }

    }

    public static bool Taka;
    //Guns Collect
    private void CollectGuns(Collider2D collision)
    {
        Taka = true;
        switch (collision.gameObject.name)
        {
            case "AK47(Clone)":
                Municao = 31;
                CheckAK = true;
                CheckSniper = false;
                CheckPistol = false;
                CheckShotGun = false;
                AAAA.sprite = PlayerAk;
                break;
            case "sniper(Clone)":
                Municao = 6;
                CheckSniper = true;
                CheckPistol = false;
                CheckAK = false;
                CheckShotGun = false;
                AAAA.sprite = PlayerSniper;
                break;

            case "Pistol(Clone)":
                Municao = 15;
                CheckAK = false;
                CheckSniper = false;
                CheckPistol = true;
                CheckShotGun = false;
                AAAA.sprite = PlayerPistol;
                break;

            case "bazooka(Clone)":
                Municao = 8;
                CheckPistol = false;
                CheckShotGun = true;
                CheckSniper = false;
                CheckAK = false;
                AAAA.sprite = PlayerShotGun;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Guns":
                Debug.Log("peguei arma");
                CollectGuns(collision);
                break;

            case "bulet":
                Death(collision);
                break;
        }
        //CollectGuns(collision);
        //Death(collision);
    }

    void Death(Collider2D collision)
    {

        switch (collision.gameObject.name)
        {
            case "BulletAk(Clone)":
                Life2.fillAmount -= 0.09f;
                break;
        }

        if (Life2.fillAmount <= 0)
            Destroy(gameObject);

        switch (collision.gameObject.name)
        {
            case "BulletPistol(Clone)":
                Life2.fillAmount -= 0.09f;
                break;
        }

        if (Life2.fillAmount <= 0)
            Destroy(gameObject);

        switch (collision.gameObject.name)
        {
            case "BulletShotgun(Clone)":
                Life2.fillAmount -= 0.3f;
                break;
        }

        if (Life2.fillAmount <= 0)
            Destroy(gameObject);

        switch (collision.gameObject.name)
        {
            case "BulletSniper(Clone)":
                Life2.fillAmount -= 0.6f;
                break;
        }

        if (Life2.fillAmount <= 0)
        {
            Destroy(gameObject);
            Wins.text = " O vencedor é \n o Jogador 1 ";
        }
    }
}

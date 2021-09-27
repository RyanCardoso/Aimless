
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SinglePlayerMove : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb2d;
    public Text TimeGame, BestTime;


    private float secondsCount;
    private int minuteCount;
    private int hourCount;

    string TempoSalvo = "TempoMelhor";

    TimeSpan BetterTime;

    string TextoExibe = "nada.";

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        BetterTime = 
            TimeSpan.FromSeconds(PlayerPrefs.GetFloat(TempoSalvo, 0));

        TextoExibe = TimeToString(BetterTime);

        if(BestTime != null)
        BestTime.text = string.Format("Melhor tempo: {0}.", TextoExibe);
    }

    string TimeToString(TimeSpan Time)
    {
        string Result = string.Empty;

        Result += string.Format("{0}", Time.Hours.ToString());
        Result += ":";

        Result += string.Format("{0}", Time.Minutes.ToString());
        Result += ":";

        Result += string.Format("{0}", Time.Seconds.ToString());

        return Result;
    }

    public void ResetarRecord()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Tutorial2");
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical") ;
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

        UpdateTimerUI();
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Porata")
        {
            if (secondsCount < BetterTime.TotalSeconds ||
                BetterTime.TotalSeconds == 0)
            {
                PlayerPrefs.SetFloat(TempoSalvo, secondsCount);
            }
        }
    }

    public void UpdateTimerUI()
    {
        secondsCount += Time.deltaTime;

        if (TimeGame != null)
        {
            TimeGame.text = string.Format("Tempo: {0}.",
                TimeToString(TimeSpan.FromSeconds(secondsCount)));
        }
    }
}


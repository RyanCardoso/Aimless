using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tempo : MonoBehaviour
{
    public Text Wins, _ResetTxt;
    private float _Reset = 6;
    private bool check = false;

    void Update()
    {
        if (Wins.text.Contains("O vencedor é \n o Jogador 1 ") || Wins.text.Contains("O vencedor é \n o Jogador 2 "))
            check = true;

        if (check)
        {
            _Reset -= Time.deltaTime;
            _ResetTxt.text = ((int)_Reset).ToString();
        }

        if (_Reset <= 1)
            SceneManager.LoadScene("Multiplayer");

    }
}

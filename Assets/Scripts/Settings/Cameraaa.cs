using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cameraaa : MonoBehaviour
{
    public Image P1, P2;
    public Text TempoTxt;
    private float TempoNuum = 4;


	void Start ()
    {
       
    }
	
	void Update ()
    {
        Mortes();
    }

    IEnumerator _Reset()
    {
        TempoTxt.text = ((int)TempoNuum).ToString();
        TempoNuum -= 1 * Time.deltaTime;
        
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Multiplayer");
        
    }
    void Mortes()
    {
        if (P1.fillAmount == 0 || P2.fillAmount == 0)     
                StartCoroutine(_Reset());
               
        
    }
}

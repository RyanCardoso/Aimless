using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuLoader : MonoBehaviour
{
    public string level = "testingscene2";

    // Use this for initialization
    void OnCollisionEnter2D(Collision2D Colider)
    {
        if (Colider.gameObject.tag == "Player")
         SceneManager.LoadScene("Main Menu");
    }
}


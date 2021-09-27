 using UnityEngine;
 using System.Collections;
using UnityEngine.SceneManagement;
 
 public class CollisionSceneChange : MonoBehaviour
 {
     static public string level = "testingscene2";
 
     // Use this for initialization
         void OnCollisionEnter2D (Collision2D Colider)
     {
         if(Colider.gameObject.tag == "Player")
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SkipTutorial()
    {
        SceneManager.LoadScene("Tutorial2");
    } 
}
using UnityEngine;
using UnityEngine.SceneManagement;
public class MultiplayerLoader : MonoBehaviour
{
    void Start()
    {
        if (Input.GetMouseButtonDown(0))

        {

            SceneManager.LoadScene("MultiPlayer");
        }
    }
}
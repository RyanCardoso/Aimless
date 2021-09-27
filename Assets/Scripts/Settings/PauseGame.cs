using UnityEngine;
using System.Collections;


public class PauseGame : MonoBehaviour
{

    bool Pause = false;



    private void Update()
    {
        DontDestroyOnLoad(this);

        if (Pause == false)
        {
            Time.timeScale = 1;
        }

        else
        {
            Time.timeScale = 0;
        }

         
        if (Input.GetKeyDown(KeyCode.P))
        {
            
            if (Pause == true)
            {
                Pause = false;
                
            }

            else
            {
                Pause = true;
                
            }
        }

                                
    }
}

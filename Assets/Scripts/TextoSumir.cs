using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoSumir : MonoBehaviour
{
    public Image Image;
    public Text Tutorial, BestTime, TimeGame;

    static float TimeNum;

    void Start()
    {
        TimeNum = 1;

        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        TimeNum += Time.deltaTime;

        if (TimeNum >= 10)
        {
            Tutorial.text = string.Empty;
            Destroy(Image);

        }
    }
}

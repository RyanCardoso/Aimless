using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnabolizantes : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.localScale += new Vector3(0.25f, 0.25f, 0); 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.localScale -= new Vector3(0.25f, 0.25f, 0);
    }

}

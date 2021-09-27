using UnityEngine;
using System.Collections;
 
public class Continue: MonoBehaviour {
 
    void Update(){
     if(Input.anyKey)
	 {
        Application.LoadLevel("Tutorial");
     }
   }
}
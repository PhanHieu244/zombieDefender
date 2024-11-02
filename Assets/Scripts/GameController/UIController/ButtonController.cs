using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

    public void OnTouchIn()
    {
        if(gameObject.name == "Button_GoToLevel")
        {

            Application.LoadLevel("Play");
        }
    }

}

using UnityEngine;
using System.Collections;

public class EnemyCard : MonoBehaviour {

    public void OnClick()
    {
        Master.PlaySoundButtonClick();
        FindObjectOfType<LibraryPanelController>().Card_OnClick(gameObject);
    }

}

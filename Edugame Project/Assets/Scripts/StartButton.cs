using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField] GameObject startMenu;
    bool isMenuOpened = false;

    public void OnButtonClick()
    {
        this.isMenuOpened = !this.isMenuOpened;
        this.startMenu.SetActive(this.isMenuOpened);
    }
}

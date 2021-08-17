using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationWindow : MonoBehaviour
{
    [SerializeField] GameObject windowBody;

    bool isNotMinimized = true; // the window is not minimized

    public void OnMinimizeClick()
    {
        this.isNotMinimized = !this.isNotMinimized;
        this.windowBody.SetActive(this.isNotMinimized);
    }

    public void OnExitClick()
    {
        this.gameObject.SetActive(false);
    }
}

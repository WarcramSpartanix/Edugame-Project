using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogIcon : MonoBehaviour
{
    [SerializeField] LogWindow logWindow;

    public void OnButtonClick()
    {
        if (!this.logWindow.gameObject.activeInHierarchy)
        {
            this.logWindow.gameObject.SetActive(true);
            this.logWindow.MaximizeWindow();
        }
    }
}

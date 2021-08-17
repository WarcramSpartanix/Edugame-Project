using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationIcon : MonoBehaviour
{
    [SerializeField] GameObject informationWindow; // window that will open

    public void OnButtonClick()
    {
        if (!this.informationWindow.activeInHierarchy)
        {
            this.informationWindow.SetActive(true);
        }
    }
}

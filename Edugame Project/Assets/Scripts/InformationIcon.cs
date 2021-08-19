using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InformationIcon : MonoBehaviour
{
    [SerializeField] InformationWindow informationWindow; // window that will open
    [SerializeField] TextMeshProUGUI nameText;

    public void OnButtonClick()
    {
        if (!this.informationWindow.gameObject.activeInHierarchy)
        {
            this.informationWindow.gameObject.SetActive(true);
            this.informationWindow.MaximizeWindow();
            this.informationWindow.transform.SetAsLastSibling();
        }
    }

    public void SetInformationWindow(InformationWindow window)
    {
        informationWindow = window;
        this.nameText = this.GetComponentInChildren<TextMeshProUGUI>();
        this.nameText.text = this.informationWindow.StowawayName + ".exe";
    }
}

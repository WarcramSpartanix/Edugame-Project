using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InformationIcon : Icon
{
    [SerializeField] TextMeshProUGUI nameText;

    public void SetInformationWindow(InformationWindow window)
    {
        this.window = window;
        this.nameText = this.GetComponentInChildren<TextMeshProUGUI>();
        this.nameText.text = this.window.GetComponent<InformationWindow>().StowawayName + ".exe";
    }
}

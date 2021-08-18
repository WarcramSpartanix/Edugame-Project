using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InformationIcon : MonoBehaviour
{
    [SerializeField] InformationWindow informationWindow; // window that will open
    [SerializeField] TextMeshProUGUI nameText;

    private void Start()
    {
        this.nameText = this.GetComponentInChildren<TextMeshProUGUI>();
        this.nameText.text = this.informationWindow.StowawayName + ".exe";
    }

    public void OnButtonClick()
    {
        if (!this.informationWindow.gameObject.activeInHierarchy)
        {
            this.informationWindow.gameObject.SetActive(true);
            this.informationWindow.MaximizeWindow();
        }
    }
}

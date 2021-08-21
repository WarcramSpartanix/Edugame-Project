using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogMessage : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI logText;

    public void AddMessage(string message)
    {
        this.logText = GetComponentInChildren<TextMeshProUGUI>();
        this.logText.text = message;
    }
}

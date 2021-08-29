using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum LogType { NONE, POOR, ADEQUATE, EXCELLENT}

public class LogMessage : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI logText;
    [SerializeField] Image emojiImage; 

    [SerializeField] Sprite poorEmoji;
    [SerializeField] Sprite adequateEmoji;
    [SerializeField] Sprite excellentEmoji;

    public void AddMessage(string message, LogType type)
    {
        this.logText = GetComponentInChildren<TextMeshProUGUI>();
        this.logText.text = message;

        switch (type)
        {
            case LogType.POOR:
                this.emojiImage.sprite = poorEmoji;
                break;

            case LogType.ADEQUATE:
                this.emojiImage.sprite = adequateEmoji;
                break;

            case LogType.EXCELLENT:
                this.emojiImage.sprite = excellentEmoji;
                break;
        }
    }
}

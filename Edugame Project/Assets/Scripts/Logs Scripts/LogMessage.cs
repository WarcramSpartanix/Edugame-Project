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

    [SerializeField] TextMeshProUGUI emojiText;

    public void AddMessage(string message, LogType type)
    {
        this.logText = GetComponentInChildren<TextMeshProUGUI>();
        this.logText.text = message;

        switch (type)
        {
            case LogType.POOR:
                this.emojiImage.sprite = poorEmoji;
                this.emojiText.text = "Poor";
                break;

            case LogType.ADEQUATE:
                this.emojiImage.sprite = adequateEmoji;
                this.emojiText.text = "Adequate";
                break;

            case LogType.EXCELLENT:
                this.emojiImage.sprite = excellentEmoji;
                this.emojiText.text = "Excellent!";
                break;
        }
    }
}

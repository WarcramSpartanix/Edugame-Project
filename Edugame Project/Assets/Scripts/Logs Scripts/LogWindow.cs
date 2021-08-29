using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LogWindow : Window
{
    List<GameObject> logMessages;
    [SerializeField] GameObject messageTemplate;
    [SerializeField] GameObject messageContainer; // area that will contain the message

    void Start()
    {
        this.logMessages = new List<GameObject>();
        this.logMessages.Add(this.GetComponentInChildren<LogMessage>().gameObject);
        this.gameObject.SetActive(false);
    }

    public void AddNewLog(string message, LogType type)
    {
        GameObject newMessage = GameObject.Instantiate(messageTemplate, this.messageContainer.transform);
        if (newMessage.GetComponentInChildren<LogMessage>() != null)
        {
            newMessage.GetComponentInChildren<LogMessage>().AddMessage(message, type);
            this.logMessages.Add(newMessage);
        }
    }

    public void ClearLogs()
    {
        foreach (GameObject log in this.logMessages)
        {
            GameObject.Destroy(log);
        }
        this.logMessages.Clear(); 
    }
}

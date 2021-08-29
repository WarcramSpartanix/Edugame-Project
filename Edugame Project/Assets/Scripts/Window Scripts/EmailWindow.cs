using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailWindow : Window
{
    List<GameObject> logMessages;
    [SerializeField] GameObject logMessageTemplate;
    [SerializeField] GameObject logMessageContainer; // area that will contain the message
    
    [SerializeField] GameObject logAlertImage; 
    bool logHasNotBeenClicked = true; // the log button has not been clicked

    [SerializeField] GameObject instructionsAlertImage;
    bool instructionsHasNotBeenClicked = true; // the instructions button has not been clicked

    [SerializeField] GameObject logsContainer; // logs panel
    [SerializeField] GameObject composeEmailContainer;
    [SerializeField] GameObject instructionsContainer; 

    // Start is called before the first frame update
    void Start()
    {
        this.logMessages = new List<GameObject>();
        this.logMessages.Add(this.GetComponentInChildren<LogMessage>().gameObject);
        this.logsContainer.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void AddNewLog(string message, LogType type)
    {
        GameObject newMessage = GameObject.Instantiate(logMessageTemplate, this.logMessageContainer.transform);
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

        this.logAlertImage.SetActive(true);
        this.logHasNotBeenClicked = true;
    }

    public void OnComposeClick()
    {
        this.logsContainer.SetActive(false);
        this.instructionsContainer.SetActive(false);
        this.composeEmailContainer.SetActive(true);
    }

    public void OnLogsClick()
    {
        this.composeEmailContainer.SetActive(false);
        this.instructionsContainer.SetActive(false);
        this.logsContainer.SetActive(true);

        if (this.logHasNotBeenClicked)
        {
            this.logAlertImage.SetActive(false);
            this.logHasNotBeenClicked = false;
        }
    }

    public void OnInstructionsClick()
    {
        this.composeEmailContainer.SetActive(false);
        this.logsContainer.SetActive(false);
        this.instructionsContainer.SetActive(true);

        if (this.instructionsHasNotBeenClicked)
        {
            this.instructionsAlertImage.SetActive(false);
            this.instructionsHasNotBeenClicked = false;
        }
    }

    public override void OnExitClick()
    {
        base.OnExitClick();
        this.logsContainer.SetActive(false);
        this.composeEmailContainer.SetActive(false);
        this.instructionsContainer.SetActive(false);
    }
}

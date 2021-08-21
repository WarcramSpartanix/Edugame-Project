using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LogWindow : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] GameObject windowBody;
    bool isNotMinimized = true; // the window is not minimized

    List<GameObject> logMessages;
    [SerializeField] GameObject messageTemplate;
    [SerializeField] GameObject messageContainer; // area that will contain the message

    private Vector2 lastMousePosition;

    void Start()
    {
        this.logMessages = new List<GameObject>();
        this.logMessages.Add(this.GetComponentInChildren<LogMessage>().gameObject);
        this.gameObject.SetActive(false);
    }

    public void AddNewLog(string message)
    {
        GameObject newMessage = GameObject.Instantiate(messageTemplate, this.messageContainer.transform);
        if (newMessage.GetComponentInChildren<LogMessage>() != null)
        {
            newMessage.GetComponentInChildren<LogMessage>().AddMessage(message);
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


    #region Window Visibility
    public void OnMinimizeClick()
    {
        this.isNotMinimized = !this.isNotMinimized;
        this.windowBody.SetActive(this.isNotMinimized);
    }

    public void MaximizeWindow()
    {
        this.isNotMinimized = true;
        this.windowBody.SetActive(true);
    }

    public void OnExitClick()
    {
        this.gameObject.SetActive(false);
    }
    #endregion

    #region Window Drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        lastMousePosition = eventData.position;
        this.transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentMousePosition = eventData.position;
        Vector2 diff = currentMousePosition - lastMousePosition;
        RectTransform rect = GetComponent<RectTransform>();

        Vector3 newPosition = rect.position + new Vector3(diff.x, diff.y, transform.position.z);
        Vector3 oldPos = rect.position;
        rect.position = newPosition;
        //if (!IsRectTransformInsideSreen(rect)) // Use this if you want to contain the window in the Scene.
        //                                       //Note: it gets kind of weird if you drag mouse out then back in, in a functioning way, that me no like.
        //{
        //    rect.position = oldPos;
        //}
        lastMousePosition = currentMousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
    }


    private bool IsRectTransformInsideSreen(RectTransform rectTransform)
    {
        bool isInside = false;
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        int visibleCorners = 0;
        Rect rect = new Rect(0, 0, Screen.width, Screen.height);
        foreach (Vector3 corner in corners)
        {
            if (rect.Contains(corner))
            {
                visibleCorners++;
            }
        }
        if (visibleCorners == 4)
        {
            isInside = true;
        }
        return isInside;
    }
    #endregion
}

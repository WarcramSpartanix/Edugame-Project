using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class InformationWindow : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] GameObject windowBody;

    bool isNotMinimized = true; // the window is not minimized


    private Vector2 lastMousePosition;

    public void OnMinimizeClick()
    {
        this.isNotMinimized = !this.isNotMinimized;
        this.windowBody.SetActive(this.isNotMinimized);
    }

    public void OnExitClick()
    {
        this.gameObject.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastMousePosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
       Vector2 currentMousePosition = eventData.position;
        Vector2 diff = currentMousePosition - lastMousePosition;
        RectTransform rect = GetComponent<RectTransform>();
 
        Vector3 newPosition = rect.position +  new Vector3(diff.x, diff.y, transform.position.z);
        Vector3 oldPos = rect.position;
        rect.position = newPosition;
        //if(!IsRectTransformInsideSreen(rect)) // Use this if you want to contain the window in the Scene.
        //                                      //Note: it gets kind of weird if you drag mouse out then back in, in a functioning way, that me no like.
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

}

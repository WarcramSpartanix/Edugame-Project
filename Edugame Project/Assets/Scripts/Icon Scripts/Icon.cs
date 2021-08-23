using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    [SerializeField] protected Window window; // window to open

    public virtual void OnButtonClick()
    {
        if (!this.window.gameObject.activeInHierarchy)
        {
            this.window.gameObject.SetActive(true);
            this.window.transform.SetAsLastSibling();
            this.window.MaximizeWindow();
        }
    }
}

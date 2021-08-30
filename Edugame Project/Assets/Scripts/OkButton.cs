using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkButton : MonoBehaviour
{
    [SerializeField] GameObject window; 
    
    public void OnButtonClick()
    {
        this.window.SetActive(false);
    }
}

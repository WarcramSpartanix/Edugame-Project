using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkButton : MonoBehaviour
{
    [SerializeField] GameObject errorWindow; 
    
    public void OnButtonClick()
    {
        this.errorWindow.SetActive(false);
    }
}

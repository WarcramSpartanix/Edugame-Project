using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailIcon : Icon
{
    [SerializeField] GameObject alertImage;
    public bool hasNotBeenClicked = true; 

    public override void OnButtonClick()
    {
        if (this.hasNotBeenClicked) // remove alert image for all instances of email icons
        {
            foreach (EmailIcon emailIcon in Resources.FindObjectsOfTypeAll(typeof(EmailIcon)) as EmailIcon[])
            {
                emailIcon.RemoveAlertImage();
            }
        }
        base.OnButtonClick();
    }

    public void ResetValues()
    {
        this.hasNotBeenClicked = true;
        this.alertImage.SetActive(true);
    }

    public void RemoveAlertImage()
    {
        this.alertImage.SetActive(false);
        this.hasNotBeenClicked = false;
    }
}

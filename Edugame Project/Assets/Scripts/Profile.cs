using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile
{
    public GameObject window;
    public GameObject icon;

    private InformationWindow windowComp;

    public Profile(GameObject window, GameObject icon)
    {
        this.window = window;
        this.icon = icon;

        this.windowComp = window.GetComponent<InformationWindow>();
    }

    public int GetScore()
    {
        return windowComp.CalculateScore();
    }

    public bool AssignedToFacilities()
    {
        return windowComp.isAssigned();
    }

    public string GetResult()
    {
        return windowComp.GetResult();
    }
}

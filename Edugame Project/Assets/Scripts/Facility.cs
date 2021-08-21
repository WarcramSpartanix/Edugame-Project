using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FacilityType
{ 
    Gym,
    Canteen,
    WaterStation,
    Pod,
    Medbay,
    RecreationArea
}

public class Facility : MonoBehaviour
{
    bool isSelected = false;
    [SerializeField] public int points; // points that will be awarded if this facility is selected

    [SerializeField] GameObject checkmark;
    [SerializeField] InformationWindow parentWindow;

    [SerializeField] public FacilityType facilityType;

    public void OnButtonClick()
    {
        bool temp = !this.isSelected; // temporarily switch the value of isSelected
        this.isSelected = this.parentWindow.CheckFacility(temp);
        this.checkmark.SetActive(this.isSelected);
    }

    public bool CheckSelection()
    {
        return this.isSelected;
    }

    public int GetPoints()
    {
        return this.points;
    }
}

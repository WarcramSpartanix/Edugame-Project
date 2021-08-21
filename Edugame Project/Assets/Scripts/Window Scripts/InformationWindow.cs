using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class InformationWindow : Window
{
    int totalScore = 0;
    [SerializeField] int numFacilities = 0; // number of facilities selected
    Facility[] facilities;

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI titleText;

    [SerializeField] TextMeshProUGUI sexText;
    [SerializeField] TextMeshProUGUI ageText;
    [SerializeField] TextMeshProUGUI reasonText;
    [SerializeField] TextMeshProUGUI profileText;
    [SerializeField] Image image;

    public string StowawayName { get; private set; } 

    [SerializeField, TextArea] string poorResult;  
    [SerializeField, TextArea] string adequateResult;  
    [SerializeField, TextArea] string excellentResult;
    string resultText;

    void Awake()
    {
        //string name = this.nameText.text;
        //name = name.Replace("Name: ", ""); // remove the Name: part of the string
        //name = name.Replace(" ", ""); // remove spaces
        //this.StowawayName = name;
        this.facilities = this.GetComponentsInChildren<Facility>();
    }

    #region Facilities Assignment
    public bool CheckFacility(bool flag)
    {
        if (flag) // facility is selected
        {
            if (this.numFacilities < 3)
            {

                this.numFacilities++;
                //Debug.Log(this.numFacilities);
                return true;
            }
        }
        else
        {
            this.numFacilities--;
        }
        return false;
    }

    public int CalculateScore()
    {
        if (this.numFacilities > 0)
        {
            foreach (Facility facility in this.facilities)
            {
                if (facility.CheckSelection())
                {
                    this.totalScore += facility.GetPoints();
                }
            }
            //Debug.Log("Total Score: " + this.totalScore);
        }
        else
        {
            Debug.Log("No facilities assigned!");
        }

        return this.totalScore;
    }

    public string GetResult()
    {
        if (this.totalScore >= 0 && this.totalScore <= 3)
        {
            this.resultText = this.poorResult;
        }
        else if (this.totalScore > 3 && this.totalScore <= 5)
        {
            this.resultText = this.adequateResult;
        }
        else if (this.totalScore > 5 && this.totalScore <= 7)
        {
            this.resultText = this.excellentResult;
        }
        //Debug.Log(this.resultText);
        return this.resultText;
    }

    public bool isAssigned()
    {
        if (this.numFacilities > 0)
            return true;
        return false;
    }
    #endregion 

    public void setProfile(StowawayProfile profile)
    {
        if(facilities == null || facilities.Length == 0) this.facilities = this.GetComponentsInChildren<Facility>();

        this.image.sprite = profile.sprite;

        this.StowawayName = profile.name;
        this.nameText.text = "Name: " + profile.name;
        this.sexText.text = "Sex: " + profile.sex;
        this.ageText.text = "Age: " + profile.age;
        this.reasonText.text = "Reason: " + profile.reason;
        this.profileText.text = "Profile: " + profile.profile;

        this.poorResult = profile.poorResult;
        this.adequateResult = profile.adequateResult;
        this.excellentResult = profile.excellentResult;
        
        foreach (Facility facility in facilities)
        {
            switch (facility.facilityType)
            {
                case FacilityType.Gym:
                    facility.points = profile.gymScore;
                    break;
                case FacilityType.Canteen:
                    facility.points = profile.canteenScore;
                    break;
                case FacilityType.WaterStation:
                    facility.points = profile.waterStationScore;
                    break;
                case FacilityType.Pod:
                    facility.points = profile.podScore;
                    break;
                case FacilityType.Medbay:
                    facility.points = profile.medbayScore;
                    break;
                case FacilityType.RecreationArea:
                    facility.points = profile.recreationAreaScore;
                    break;
                default:
                    break;
            }
        }
        
        this.titleText.text = this.StowawayName + ".exe";
    }
}

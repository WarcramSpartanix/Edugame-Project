using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "StowawayProfile", menuName = "ScriptableObjects/StowawayProfile", order = 1)]
public class StowawayProfile : ScriptableObject
{
    

    public Sprite sprite;

    public string name;
    public string age;
    public string sex;
    [SerializeField, TextArea] public string reason;
    [SerializeField, TextArea] public string profile;

    public int gymScore;
    public int canteenScore;
    public int waterStationScore;
    public int podScore;
    public int medbayScore;
    public int recreationAreaScore;

    [SerializeField, TextArea] public string poorResult;
    [SerializeField, TextArea] public string adequateResult;
    [SerializeField, TextArea] public string excellentResult;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[CreateAssetMenu(fileName = "profilePair", menuName = "ScriptableObjects/profilePair", order = 1)]
//public class profilePair : ScriptableObject
//{
//    public StowawayProfile prof;
//    public bool isUsed;

//    public profilePair(StowawayProfile prof, bool used = false)
//    {
//        this.prof = prof;
//        isUsed = used;
//    }
//    public void Used()
//    {
//        isUsed = true;
//    }
//}

public class GameManager : MonoBehaviour
{
    //public static GameManager instance { get; private set; }

    //private void Awake()
    //{
    //    instance = this;
    //}

    public List<StowawayProfile> profilePrefabList;
    public GameObject informationIconPrefab;
    public GameObject stowawayPrefab;

    private List<Profile> profileList;
    [SerializeField] LogWindow logWindow;
    
    private int score = 0;

    private int weekNum = 0;
    [SerializeField]private List<int> stowawayWeekNum;

    private void Start()
    {
        profileList = new List<Profile>();
        SpawnBatch(stowawayWeekNum[weekNum]);
        
    }

    public void SpawnBatch(int count)
    {
        float x = 100;
        for (int i = 0; i < count; i++, x+=150)
        {
            int rand;
            rand = Random.Range(0, profilePrefabList.Count); 



            GameObject iconTemp = Spawn(rand);
            iconTemp.transform.position = new Vector2(x, 250);

            profilePrefabList.RemoveAt(rand);
        }  
    }

    public GameObject Spawn(int index)
    {
        GameObject windowTemp = Instantiate(stowawayPrefab, this.transform);

        //  information window init
        windowTemp.transform.SetAsLastSibling();
        windowTemp.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);
        windowTemp.GetComponent<InformationWindow>().setProfile(profilePrefabList[index]);
        windowTemp.SetActive(false);

        GameObject iconTemp = Instantiate(informationIconPrefab, this.transform);
        iconTemp.transform.SetAsFirstSibling();
        iconTemp.GetComponent<InformationIcon>().SetInformationWindow(windowTemp.GetComponent<InformationWindow>());

        profileList.Add(new Profile(windowTemp, iconTemp));

        return iconTemp;
    }

    public void ClearProfiles()
    {
        for (int i = profileList.Count -1; i >= 0; i--)
        {
            Destroy(profileList[i].window);
            Destroy(profileList[i].icon);
        }
        profileList.Clear();
    }

    public void EvaluateWeek()
    {
        foreach (Profile profile in profileList)
        {
            if (!profile.AssignedToFacilities())
            {
                Debug.Log("Not all are assigned");
                return;
            }
        }

        this.logWindow.ClearLogs();
        foreach (Profile profile in profileList)
        {
            this.score += profile.GetScore();
            this.logWindow.AddNewLog(profile.GetResult());
        }

        Debug.Log("Weekly Evaluation is " + this.score);

        NextWeek();
    }

    public void NextWeek()
    {
        weekNum++;
        if (weekNum < stowawayWeekNum.Count)
        {
            ClearProfiles();
            SpawnBatch(stowawayWeekNum[weekNum]);
        }
    }
}

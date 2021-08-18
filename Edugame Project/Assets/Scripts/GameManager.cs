using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    //public static GameManager instance { get; private set; }

    //private void Awake()
    //{
    //    instance = this;
    //}


    public List<GameObject> profilePrefabList;
    public GameObject informationIconPrefab;

    private List<Profile> profileList;
    
    private int score = 0;

    private void Start()
    {
        profileList = new List<Profile>();
        SpawnBatch(3);
        
    }

    public void SpawnBatch(int count)
    {
        float x = 100;
        for (int i = 0; i < count; i++, x+=150)
        {
            GameObject iconTemp = Spawn(Random.Range(0, profilePrefabList.Count));
            iconTemp.transform.position = new Vector2(x, 250);
        }  
    }

    public GameObject Spawn(int index)
    {
        GameObject windowTemp = Instantiate(profilePrefabList[index], this.transform);
        windowTemp.transform.SetAsLastSibling();
        windowTemp.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);
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

        foreach (Profile profile in profileList)
        {
            this.score += profile.GetScore();
        }

        Debug.Log("Weekly Evaluation is " + this.score);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame3 : MonoBehaviour
{
    private bool isPlaying = true;

    [SerializeField] private GameObject oxygenPanel;
    [SerializeField] private GameObject carbonDioxidePanel;
    [SerializeField] private Timer timer;

    [SerializeField] private GameObject oxygenPrefab;
    [SerializeField] private GameObject carbonDioxidePrefab;

    [SerializeField] private int totalParticles;    // total particles to spawn and assign
    private int assignedParticleCount = 0;      // number of particles assigned to panel

    private void Start()
    {
        for (int i = 0; i < totalParticles; i++)
        {
            GameObject temp;
            Vector3 offset = new Vector3(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f));
            if (Random.Range(0, 2) % 2 == 0)
            {
                temp = Instantiate(oxygenPrefab, this.transform);    
            }
            else
            {
                temp = Instantiate(carbonDioxidePrefab, this.transform);
            }

            temp.transform.Translate(offset);
            temp.GetComponent<GasParticle>().manager = this;
        }
    }

    private void Update()
    {
        if (isPlaying)
        {
            if (assignedParticleCount >= totalParticles)
            {
                Debug.Log("Win");
                isPlaying = false;
                timer.isPlaying = false;
            }
            else if (timer.timeSlider.value <= 0.0f) 
            {
                Debug.Log("Lose");
                isPlaying = false;
                timer.isPlaying = false;
            }
        }
    }

    public GasParticle.GasType IsMouseOverGasPanel()
    {
        RectTransform oxygenRect = oxygenPanel.GetComponent<RectTransform>();
        RectTransform carbonDioxideRect = carbonDioxidePanel.GetComponent<RectTransform>();

        if (RectTransformUtility.RectangleContainsScreenPoint(oxygenRect, Input.mousePosition))
        {
            return GasParticle.GasType.Oxygen;
        }
        else if (RectTransformUtility.RectangleContainsScreenPoint(carbonDioxideRect, Input.mousePosition))
        {
            return GasParticle.GasType.CarbonDioxide;
        }
        else
            return GasParticle.GasType.None;
    }

    public void AssignedParticle()
    {
        assignedParticleCount++;
    }

    public void Gameover()
    {
    }
}

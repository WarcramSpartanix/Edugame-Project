using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame3 : MonoBehaviour
{
    private bool isPlaying = true;

    [SerializeField] private GameObject oxygenPanel;
    [SerializeField] private GameObject carbonDioxidePanel;
    [SerializeField] private Timer timer;
    [SerializeField] private Image vignetteImage;

    [SerializeField] private GameObject oxygenPrefab;
    [SerializeField] private GameObject carbonDioxidePrefab;

    [SerializeField] private int totalParticles;    // total particles to spawn and assign
    private int spawnedParticlesCount = 0;
    private int assignedParticleCount = 0;      // number of particles assigned to panel
    private float timeElapsed = 0;
    private float deltaSpawnTime = 0;

    private void Start()
    {
        SpawnParticle();

        float timerDuration = timer.timeSlider.maxValue / timer.tickRate;   // in Seconds
        timerDuration -= timerDuration * 0.25f; // make sure there is at least 25% of the duration left before the last particle spawns
        deltaSpawnTime = timerDuration / (totalParticles - 1);
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

        timeElapsed += Time.deltaTime;
        if (timeElapsed >= deltaSpawnTime)
        {
            SpawnParticle();
            timeElapsed -= deltaSpawnTime;
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

    public void SpawnParticle(bool isOveridden = false)
    {
        if (!isOveridden)
        {
            if (spawnedParticlesCount >= totalParticles)
                return;
        }

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

        spawnedParticlesCount++;
    }

    public void IncreaseVignette()
    {
        Color colorTemp = new Color(0, 0, 0, vignetteImage.color.a);
        colorTemp.a += 0.15f;
        vignetteImage.color = colorTemp;
    }

    public void Gameover()
    {
    }
}

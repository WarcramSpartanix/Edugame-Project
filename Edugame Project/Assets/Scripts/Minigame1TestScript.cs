using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Minigame1TestScript : MonoBehaviour
{
    bool isPlaying = true; // is minigame playing

    [SerializeField] Slider slider;

    enum MinigameState { WALK, BRISKWALK, RUN}
    MinigameState currentState = MinigameState.WALK;

    float ticks = 0.0f;

    [SerializeField] float walkMinTime = 1.5f;
    [SerializeField] float walkMaxTime = 2.0f;

    [SerializeField] float briskWalkMinTime = 1.0f;
    [SerializeField] float briskWalkMaxTime = 1.5f;

    [SerializeField] float runMinTime = 0.5f;
    [SerializeField] float runMaxTime = 1.0f;

    float interval = 0.0f; // time before the value decreases

    float stateTicks = 0.0f;
    [SerializeField] float stateInterval = 3.0f; // time before the state changes

    [SerializeField] Timer timer;

    private void Start()
    {
        this.GenerateRandomIntervalValue();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isPlaying)
        {
            // check for failure condition
            if (slider.value >= slider.maxValue || slider.value <= 0) // value reached extreme sides
            {
                Debug.Log("Lose :(");
                this.isPlaying = false;
                this.timer.isPlaying = false;
            }
            if (timer.timeSlider.value <= 0)
            {
                this.isPlaying = false;
                this.timer.isPlaying = false;
                this.CheckResult();
            }

            // slider value timer
            this.ticks += Time.deltaTime;
            if (this.ticks >= this.interval)
            {
                this.ticks = 0;
                this.slider.value--;
                this.GenerateRandomIntervalValue();
            }

            // minigame state timer
            if (this.currentState != MinigameState.RUN)
            {
                this.stateTicks += Time.deltaTime;
                if (this.stateTicks >= this.stateInterval)
                {
                    this.stateTicks = 0;
                    this.currentState++; 
                }
            }
        }
    }

    public void OnButtonClick()
    {
        if (this.isPlaying)
        {
            this.slider.value++;
        }
    }

    void CheckResult()
    {
        if (this.slider.value >= 4 && this.slider.value <= 6)
        {
            Debug.Log("Win!");
        }
        else
        {
            Debug.Log("Lose :(");
        }
    }

    // randomly generate a value for interval variable
    void GenerateRandomIntervalValue()
    {
        if (this.currentState == MinigameState.WALK)
        {
            this.interval = Random.Range(this.walkMinTime, this.walkMaxTime);
            Debug.Log("Current state: WALK");
        }
        else if (this.currentState == MinigameState.BRISKWALK)
        {
            this.interval = Random.Range(this.briskWalkMinTime, this.briskWalkMaxTime);
            Debug.Log("Current state: BRISK WALK");
        }
        else if (this.currentState == MinigameState.RUN)
        {
            this.interval = Random.Range(this.runMinTime, this.runMaxTime);
            Debug.Log("Current state: RUN");
        }
    }
}

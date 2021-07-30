using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float tickRate = 1.0f; //  slider value reduced per second

    public Slider timeSlider;

    public bool isPlaying = true;

    private void Start()
    {
        timeSlider.value = timeSlider.maxValue;
    }

    private void Update()
    {
        if (isPlaying)
        {
            float tickValue = tickRate * Time.deltaTime;
            timeSlider.value -= tickValue;
        }
    }
}

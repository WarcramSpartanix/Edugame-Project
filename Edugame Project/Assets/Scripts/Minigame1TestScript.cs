using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Minigame1TestScript : MonoBehaviour
{
    bool isPlaying = true; // is minigame playing

    [SerializeField] Slider slider;
    [SerializeField] Slider timerSlider;

    float valueTicks = 0.0f;
    [SerializeField] float valueTimer = 2.0f; // time before slider value decreases

    float ticks = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (this.isPlaying)
        {
            this.valueTicks += Time.deltaTime;
            this.ticks += Time.deltaTime;
            if (this.valueTicks >= this.valueTimer)
            {
                slider.value--;
                this.valueTicks = 0;
            }
            if (this.ticks >= 1.0f)
            {
                this.timerSlider.value--;
                this.ticks = 0;
                if (this.timerSlider.value == 0)
                {
                    this.CheckResult();
                    this.isPlaying = false;
                }
            }
        }
    }

    public void OnButtonClick()
    {
        slider.value++; 
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
}

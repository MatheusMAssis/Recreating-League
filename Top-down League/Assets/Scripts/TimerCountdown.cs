using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerCountdown : MonoBehaviour
{
    public int timerMax;

    TextMeshProUGUI textMeshComponent;
    float countdown;

    void Start()
    {
        textMeshComponent = GetComponent<TextMeshProUGUI>();
        textMeshComponent.text = timerMax.ToString();
        countdown = timerMax;
    }

    void Update()
    {
        countdown -= Time.deltaTime;

        textMeshComponent.text = Mathf.RoundToInt(countdown).ToString();
    }
}

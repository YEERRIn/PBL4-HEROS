using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class CurrentTime : MonoBehaviour
{
    // Text UI ���
    public Text timeText;

    // �Ǵ� TMPro ���
    public TextMeshProUGUI timeTextMeshPro;

    void Start()
    {
        // Invoke the UpdateTime method every second
        InvokeRepeating("UpdateTime", 0f, 1f);
    }

    void UpdateTime()
    {
        // Get the current system time
        System.DateTime currentTime = System.DateTime.Now;

        // Format the time and date as a string
        string timeString = currentTime.ToString("HH:mm:ss");
        string dateString = currentTime.ToString("yyyy�� MM�� dd��");

        // Update the UI text with the current time and date
        // Text UI ���
        if (timeText != null)
            timeText.text = dateString + " " + timeString;

        // �Ǵ� TMPro ���
        if (timeTextMeshPro != null)
            timeTextMeshPro.text = dateString + " " + timeString;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    float currentTime;
    int displayTime;
    float passedTime;
    float startTime = 100;
    [SerializeField] GameObject display;


    void FixedUpdate()  
    {
        passedTime = Time.time;
        currentTime = startTime - passedTime;
        displayTime = Mathf.RoundToInt(currentTime);

        display.GetComponent<TextMeshProUGUI>().text = displayTime.ToString();

        if (currentTime <= 0)
        {
            SceneManager.LoadScene(3); //TimeUp scene
        }
    }
}

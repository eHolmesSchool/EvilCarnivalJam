using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    float currentTime;
    int displayTime;
    float passedTime;
    float startTimeLimit = 101;  //101
    float startTime;
    [SerializeField] GameObject display;

    private void OnEnable()
    {
        
    }

    private void Start()
    {
        startTime = Time.time;
    }

    void FixedUpdate()  
    {
        passedTime = Time.time- startTime;
        currentTime = startTimeLimit - passedTime;
        displayTime = Mathf.RoundToInt(currentTime);

        display.GetComponent<TextMeshProUGUI>().text = displayTime.ToString();

        if (currentTime <= 0)
        {
            SceneManager.LoadScene(3); //TimeUp scene
        }
    }
}

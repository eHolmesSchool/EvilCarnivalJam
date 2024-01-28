using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AxeMenDisp : MonoBehaviour
{
    public static int killsL;
    public static int killsR;
    public static int totalKills;
    public TextMeshProUGUI scoreDisplay;

    private void Awake()
    {
        scoreDisplay = GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        totalKills = killsL + killsR;
        scoreDisplay.text = totalKills.ToString();
    }
}

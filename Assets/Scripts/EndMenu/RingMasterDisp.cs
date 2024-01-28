using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RingMasterDisp : MonoBehaviour
{
    public static int kills;
    public TextMeshProUGUI scoreDisplay;

    private void Awake()
    {
        scoreDisplay = GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        scoreDisplay.text = kills.ToString();
    }
}

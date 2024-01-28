using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TigerDisp : MonoBehaviour
{
    public static int kills;
    public static TextMeshProUGUI scoreDisplay;

    private void Start()
    {
        scoreDisplay = GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        scoreDisplay.text = kills.ToString();
    }
}

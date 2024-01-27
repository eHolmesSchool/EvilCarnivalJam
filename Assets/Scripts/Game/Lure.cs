using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lure : MonoBehaviour
{
    List<LittleMan> littleMen;

    void Start()
    {
        littleMen = new List<LittleMan>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        LittleMan otherMan = other.GetComponent<LittleMan>();
    }
}

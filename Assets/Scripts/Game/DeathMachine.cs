using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMachine : MonoBehaviour
{
    HurtBox hurtbox;
    public int fearRadius;
    public int killCount = 0;
    public int deathMachineNumb = 0;   //USED if we implement varying death poses

    private void Start()
    {
        killCount = 0;
        hurtbox = GetComponentInChildren<HurtBox>();
    }

    private void FixedUpdate()
    {
        BeWitnessed(tag);
    }

    private void BeWitnessed(string tag)
    {
        //Find everything by it's Tag lmao
        ///Shark, Tiger, Axe, RingMast                      For getting killCount
        ///SharkDisplay, TigerDisplay, AxeDisplay, RingMastDisplay      For putting counts into proper displays
        ///

        if (tag == "Tiger")
        {
            TigerDisp.kills = killCount;
        }
    }

    public void Clicked()
    {
        hurtbox.Activate();
    }

    public void KillUp()
    {
        killCount++;
    }
}

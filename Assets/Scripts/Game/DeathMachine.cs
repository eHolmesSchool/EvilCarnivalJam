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
    AudioSource speaker;

    private void Start()
    {
        speaker = GetComponent<AudioSource>();
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
        else  if (tag == "RingMaster")
        {
            RingMasterDisp.kills = killCount;
        }
        else if (tag == "AxeMenL")
        {
            AxeMenDisp.killsL = killCount;
        }
        else if (tag == "AxeMenR")
        {
            AxeMenDisp.killsR = killCount;
        }
        else if (tag == "Shark")
        {
            SharkDisp.kills = killCount;
        }
    }

    public void Clicked()
    {
        hurtbox.Activate();
        speaker.Stop();
        speaker.Play();
    }

    public void KillUp()
    {
        killCount++;
    }
}

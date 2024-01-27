using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMachine : MonoBehaviour
{
    HurtBox hurtbox;
    int fearRadius;
    int killCount=0;
    int deathMachineNumb = 0;   //USED if we implement varying death poses

    private void Start()
    {
        killCount = 0;
        hurtbox = GetComponentInChildren<HurtBox>();
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

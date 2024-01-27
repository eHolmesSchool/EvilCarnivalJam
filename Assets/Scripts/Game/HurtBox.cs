using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurtBox : MonoBehaviour
{
    int lifeFrames = 20 ;
    int startFrame = 0;
    int currentFrame = 0;
    state currentState;
    Collider coll;
    Image image;
    [SerializeField] DeathMachine machine;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
        image = GetComponent<Image>();
        currentState = state.Inactive;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentFrame++;

        if (currentState == state.Active)
        {
            image.enabled = true;
            coll.enabled = true;
            if (currentFrame - startFrame >= lifeFrames)
            {
                Deactivate();
            }
        }
        else
        {
            image.enabled = false;
            coll.enabled = false;
        }
    }

    public void Activate()
    {

        startFrame = currentFrame;
        currentState = state.Active;
    }

    public void Deactivate()
    {
        currentState = state.Inactive;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collObj = other.gameObject;
        LittleMan collMan = collObj.GetComponent<LittleMan>();
        if (collMan != null)
        {
            collMan.Die(machine);
        }
        //Debug.Log("CollEnter");
    }

    enum state
    {
        Active,
        Inactive
    }
}

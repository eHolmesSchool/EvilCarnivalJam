using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class HurtBox : MonoBehaviour
{
    int lifeFrames = 20;
    int startFrame = 0;
    int currentFrame = 0;
    float moveSpeed = 10;
    state currentState;
    Collider coll;
    Image image;
    [SerializeField] Vector3 initialOffset;
    [SerializeField] Vector3 finalOffset;
    [SerializeField] DeathMachine machine;

    //OPTIONAL track number of people inside box and play a different death sound
    //based on number of kills in one mov

    void Start()
    {
        coll = GetComponent<Collider>();
        image = GetComponent<Image>();
        currentState = state.Inactive;
    }

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

            //Move();   //Fix thiss Last
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
        transform.SetLocalPositionAndRotation(initialOffset, transform.localRotation);
        currentState = state.Active;
    }

    public void Deactivate()
    {
        currentState = state.Inactive;
    }

    void Move()
    {
        transform.Translate(Vector3.Normalize(finalOffset - transform.localPosition) * moveSpeed);
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

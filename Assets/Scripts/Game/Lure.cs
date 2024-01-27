using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lure : MonoBehaviour
{
    List<LittleMan> littleMen;
    [SerializeField]List<Transform> moveTransforms;
    Vector3 currentMovePos;
    int currentMovePosNumb = 0;
    float moveSpeed = 1;
    float movePosSwitchDist = 10;

    state currentState;

    void Start()
    {
        littleMen = new List<LittleMan>();
        currentState = state.Inactive;
        currentMovePos = moveTransforms[currentMovePosNumb].position;
    }

    void Update()
    {
        if (currentState == state.Active)
        {
            for (int i = 0; i < littleMen.Count; i++)
            {
                littleMen[i].Lure(transform.position);
            }
        }
        else
        {
            Move();
        }
    }

    private void Move()
    {
        Debug.Log(currentMovePosNumb);
        currentMovePos = moveTransforms[currentMovePosNumb].position;
        transform.Translate(Vector3.Normalize(currentMovePos - transform.position) * moveSpeed);

        if (Vector3.Distance(transform.position, currentMovePos) <= movePosSwitchDist)
        {
            if (currentMovePosNumb == moveTransforms.Count - 1)
            {
                currentMovePosNumb = 0;
            }
            else
            {
                currentMovePosNumb++;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {//Track the people in our radius
        LittleMan otherMan = other.GetComponent<LittleMan>();
        if (otherMan != null)
        {
            littleMen.Add(otherMan);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        LittleMan otherMan = other.GetComponent<LittleMan>();
        if (otherMan != null)
        {
            for (int i = 0; i < littleMen.Count; i++)
            {
                if (littleMen[i] == otherMan)
                {
                    littleMen.RemoveAt(i);
                }
            }
        }
    }

    public void Click()
    {

        if (currentState == state.Active)
        {
            currentState = state.Inactive;
        }
        else
        {
            currentState = state.Active;
        }
    }

    enum state
    {
        None,
        Active,
        Inactive,
    }
}

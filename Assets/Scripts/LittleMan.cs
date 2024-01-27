using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LittleMan : MonoBehaviour
{
    /// <summary>
    /// What do we need?
    /// Walk aimlessly
    /// Walk towards something
    /// Run away from something
    /// Stand still
    /// Die lmao + Blood reveal
    /// Array of Images - Stand, StepL, StepR, DeadGen, DeadAxe, DeadTiger, DeadWhip, DeadAxe2, DeadTiger2, DeadWhip2
    /// States:
    /// Walk - Alternate between WalkL, Stand, WalkR, Stand. Switch every 1/3rd second?. 
    ///     Slide gameobject in the direction of the MovePos. MovePos X and Y picked Randomly between set values
    ///     
    /// Dead - Stationary. 
    /// Standing - Standing pose, not moving
    /// RunAway - Walk code but frames between is shorter
    /// Lured - Triggered when in the radius of the Active Good attraction, overrides Fear and Walk
    /// 
    /// MovePosition - The thing it is moving towards
    /// FearPosition - A murder scene we are running away from. Find that direction and move opposite
    /// 
    /// </summary>

    Vector3 movePos = Vector3.zero;
    Vector3 moveDir = Vector3.zero;
    [SerializeField]state currentState = state.Stand;
    float moveSpeed = 1;

    [SerializeField] List<Image> imageList = new List<Image>();

    [SerializeField] GameObject wanderTargetTemp;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        switch (currentState) {
        
            case state.Stand:
                break;
            case state.Wander:
                transform.LookAt(wanderTargetTemp.transform);
                transform.Translate(Vector3.forward * moveSpeed);
                break;
            case state.Flee:
                break;
            case state.Lured:
                break;
            case state.Dead:
                break;

        }
    }

    enum state
    {
        Stand,
        Wander,
        Flee,
        Lured,
        Dead,

    }
}

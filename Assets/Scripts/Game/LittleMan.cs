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
    /// Images: Stand, DeadGen, DeadTiger, DeadAxe, DeadWhip, DeadGen2, DeadTiger2, DeadAxe2, DeadWhip2
    /// </summary>

    Vector3 pos;

    [SerializeField] public state currentState = state.Wander;  //Start as Stand in finished game
    float moveSpeed = 1f;

    [SerializeField] List<Sprite> imageList = new List<Sprite>();
    Billboard billboard;
    Image image;
    Sprite sprite;

    int frameDelayStandard = 60;    //Number of frames per second approximately
    int wanderFrameDiff;
    int sprintFrameDiff;
    int wanderFramesDivisor = 3;
    int sprintFramesDivisor = 4;

    int stepFrame = 0;
    int currentFrame = 0;
    int walkCycleNumb = 0;

    float walkStepSpriteRot = 20;
    float walkStepSpriteOffsetHoriz = 1;
    float walkStepSpriteOffsetVert = 1;
    float desiredZRot = 0;
    float wanderStopRadius = 20;

    int FIXEDZ = 100;

    Vector3 wanderPos;
    Vector3 fleePos;

    int stateStartFrame = 0;
    int stateCurrentFrame = 0;
    int standDelayFrames;

    int minWanderX = -100;
    int minWanderY = -50;
    int maxWanderX = 100;
    int maxWanderY = 50;


    void Start()
    {
        wanderPos = new Vector3(0, 10, FIXEDZ);
        standDelayFrames = frameDelayStandard;
        pos = transform.position;
        billboard = GetComponentInChildren<Billboard>();
        image = GetComponentInChildren<Image>();
        sprite = image.sprite;

        wanderFrameDiff = Mathf.RoundToInt(frameDelayStandard / 3);
        sprintFrameDiff = Mathf.RoundToInt(frameDelayStandard / 4);
    }

    void FixedUpdate()
    {
        pos = transform.position;
        MoveUpdate();
        SpriteUpdate();
        billboard.BillboardUpdate(desiredZRot);
    }

    void MoveUpdate()
    {
        //TEMP
        //wanderPos = wanderTargetTemp.transform.position;

        stateCurrentFrame++;

        //Debug.Log($"Wander:{wanderPos} Current:{pos}");

        switch (currentState)
        {
            case state.Stand:
                //Blank, no moving
                if (stateCurrentFrame - stateStartFrame >= standDelayFrames)
                {
                    StateChange(state.Wander);
                }
                break;
            case state.Wander:
                transform.Translate(Vector3.Normalize(wanderPos - transform.position) * moveSpeed);

                if (Vector3.Distance(pos,wanderPos) <= wanderStopRadius)
                {
                    StateChange(state.Stand);
                }
                break;
            case state.Flee:
                //Get the transform of ScaryPos, and move away. Maybe this ^^ but adding? opposite order?
                break;
            case state.Lured:
                //Wander code basically
                break;
            case state.Dead:
                //Blank, no moving
                break;
        }
    }

    void SpriteUpdate()
    {
        currentFrame++;

        switch (currentState)
        {
            case state.Stand:
                sprite = imageList[0];
                image.transform.position = transform.position;
                desiredZRot = 0;
                walkCycleNumb = 0;
                break;
            case state.Wander:
                if (currentFrame - stepFrame >= wanderFrameDiff) 
                {//At the end of step timer
                    if (walkCycleNumb == 0)
                    {//If we were at pose 1 AKA standing1
                        sprite = imageList[0];
                        image.transform.position = transform.position + new Vector3(walkStepSpriteOffsetHoriz, walkStepSpriteOffsetVert, 0);
                        desiredZRot = -walkStepSpriteRot;
                        walkCycleNumb = 1;
                    }//Move to Walk Left
                    else if (walkCycleNumb == 1)
                    {//If we were on WalkL
                        sprite = imageList[0];
                        image.transform.position = transform.position;
                        desiredZRot = 0;
                        walkCycleNumb = 2;
                    }//Go back to standing
                    else if (walkCycleNumb == 2)
                    {//If we were on standing2
                        sprite = imageList[0];
                        image.transform.position = transform.position + new Vector3(-walkStepSpriteOffsetHoriz, walkStepSpriteOffsetVert, 0);
                        desiredZRot = walkStepSpriteRot;
                        walkCycleNumb = 3;
                    }//Go to WalkR
                    else if (walkCycleNumb == 3)
                    {//If we were on WalkR
                        sprite = imageList[0];
                        image.transform.position = transform.position;
                        desiredZRot = 0;
                        walkCycleNumb = 0;
                    }//Go back to standing
                    stepFrame = currentFrame;
                }
                break;
            case state.Flee:
                //Get the transform of ScaryPos, and move away. Maybe this ^^ but adding? opposite order?
                break;
            case state.Lured:
                //Wander code basically
                break;
            case state.Dead:
                sprite = imageList[1];
                break;
        }

        image.sprite = sprite;
        if (wanderPos.x < transform.position.x)
        {//If target is to the left
            image.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }//Face left (Normal)
        else {
            image.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }//Face Right (Flipped) (notice the negative ^here)
    }

    private void StateChange(state newState)
    {
        stateStartFrame = stateCurrentFrame;
        currentState = newState;
        if (newState == state.Stand)
        {
            NewWanderPos();
        }
    }

    void NewWanderPos()
    {
        wanderPos = new Vector3(Random.Range(minWanderX, maxWanderX), Random.Range(minWanderY, maxWanderY), FIXEDZ);
    }

    public void Die(DeathMachine machine)
    {
        if (currentState != state.Dead)
        {
            machine.KillUp();
            currentState = state.Dead;
        }        
        //Play Soundfx
    }

    public void Lure(Vector3 newTargetPos)
    {//
        wanderPos = newTargetPos;
    }

    public enum state
    {
        Stand,
        Wander,
        Flee,
        Lured,
        Dead,
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuManager : MonoBehaviour
{
    [SerializeField] public static int tigerKills;
    [SerializeField] public static int ringMasterKills;
    [SerializeField] public static int axeMenKills;
    public static int totalKills;
    public static Ending currentEnding;

    void Start()
    {

    }

    void FixedUpdate()
    {
        tigerKills = TigerDisp.kills;
        ringMasterKills = RingMasterDisp.kills;
        axeMenKills = AxeMenDisp.totalKills;
        currentEnding = SolveEnding();

        Debug.Log(currentEnding.ToString());
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(4);
    }

    Ending SolveEnding()
    {
        Ending solvedEnding = Ending.RingMaster;

        if (tigerKills + axeMenKills + ringMasterKills <= 0)
        {
            solvedEnding = Ending.Pacifist;
        }
        else if (tigerKills > axeMenKills && tigerKills > ringMasterKills)
        {   //Tiger win
            solvedEnding = Ending.Tiger;
        }
        else if (axeMenKills > tigerKills && axeMenKills > ringMasterKills)
        {   //Axe win
            solvedEnding = Ending.AxeMen;
        }
        else
        {   //RingMaster win
            solvedEnding = Ending.RingMaster;
        }
        return solvedEnding;
    }

    public enum Ending
    {
        None,
        Tiger,
        AxeMen,
        RingMaster,
        Pacifist,
    }
}

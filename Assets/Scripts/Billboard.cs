using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] GameObject lookAt;
    public bool isBillboarding;

    public void BillboardUpdate(float desiredZRot)
    {
        if (isBillboarding)
        {
            transform.LookAt(lookAt.transform);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, desiredZRot);
        }
    }
}

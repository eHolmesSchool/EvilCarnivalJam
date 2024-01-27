using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] GameObject lookAt;
    public bool isBillboarding;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isBillboarding)
        {
            transform.LookAt(lookAt.transform);
        }
    }
}

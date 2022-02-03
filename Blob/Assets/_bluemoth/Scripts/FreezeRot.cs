using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRot : MonoBehaviour
{
    public Vector3 freezeRotation;
    public bool freezeWorld = true;
    public bool x, y, z;

    private void Update()
    {
        if (!freezeWorld)
        {
            FreezeLocalRot();
        } 
        else
        {
            FreezeWorldRot();
        }
    }

    private void FreezeLocalRot()
    {
        Quaternion currentRot = transform.localRotation;

        transform.localRotation = Quaternion.Euler(x ? freezeRotation.x : currentRot.eulerAngles.x,
                                                   y ? freezeRotation.y : currentRot.eulerAngles.y,
                                                   z ? freezeRotation.z : currentRot.eulerAngles.z);
    }

    private void FreezeWorldRot()
    {
        Quaternion currentRot = transform.rotation;

        Debug.Log(currentRot.eulerAngles);
        transform.rotation = Quaternion.Euler(x ? freezeRotation.x : currentRot.eulerAngles.x,
                                              y ? freezeRotation.y : currentRot.eulerAngles.y,
                                              z ? freezeRotation.z : currentRot.eulerAngles.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public SpriteRenderer sr;

    public void OpenGate(Sprite s)
    {
        sr.sprite = s;
    }

    public void CloseGate(Sprite s)
    {
        sr.sprite = s;
    }
}

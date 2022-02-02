using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;

public class UIManager : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void CorgiPauseToggle()
    {
        CorgiEngineEvent.Trigger(CorgiEngineEventTypes.TogglePause);
    }
}

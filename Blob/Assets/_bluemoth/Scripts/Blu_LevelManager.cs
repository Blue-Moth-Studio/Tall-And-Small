using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System;
using Rewired;
using UnityEngine.UI;

public class Blu_LevelManager : MonoBehaviour
{
    private GameObject[] characters;

    private List<GameObject> currentCharacters;

    public Canvas gameEndingScreen;
    public Canvas gameOverScreen;
    public Canvas pauseScreen;

    public Button gameEndingFocus;
    public Button gameOverFocus;
    public Button pauseFocus;

    private Player p1;
    private Player p2;

    private int playersAlive = 2;

    public void TogglePauseScreen()
    {
        bool isActive = pauseScreen.gameObject.activeInHierarchy;
        Debug.Log("Canvas is active: " + isActive);
        pauseScreen.gameObject.SetActive(!isActive);
    }

    public void PlayerDeath()
    {
        Debug.Log("Player Died");
        playersAlive--;
        if (playersAlive <= 0)
        {
            ShowGameOver();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        characters = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(characters.Length);

        p1 = ReInput.players.GetPlayer(0);
        p2 = ReInput.players.GetPlayer(1);

        foreach (Character c in LevelManager.Instance.Players)
        {
            c.CharacterHealth.OnDeath += PlayerDeath;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (characters.Length < 2)
        {
            characters = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject g in characters)
            {
                Debug.Log(g);
            }
            if (characters.Length == 2)
            {
                ProCamera2D.Instance.AddCameraTarget(characters[0].transform);
                ProCamera2D.Instance.AddCameraTarget(characters[1].transform);
            }
        } else if (characters.Length == 2 && ProCamera2D.Instance.CameraTargets.Count < 2)
        {
            ProCamera2D.Instance.AddCameraTarget(characters[0].transform);
            ProCamera2D.Instance.AddCameraTarget(characters[1].transform);
        }

        if (p1 == null || p2 == null)
        {
            p1 = ReInput.players.GetPlayer(0);
            p2 = ReInput.players.GetPlayer(1);
        }
        if (p1.GetButtonDown("Pause") || p2.GetButtonDown("Pause"))
        {
            TogglePauseScreen();
        }

        
    }

    public void ShowEnding()
    {
        gameEndingScreen.gameObject.SetActive(true);
        CorgiEngineEvent.Trigger(CorgiEngineEventTypes.TogglePause);
    }

    public void ShowGameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
        CorgiEngineEvent.Trigger(CorgiEngineEventTypes.TogglePause);
    }
}

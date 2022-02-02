using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class GameEnd : MonoBehaviour
{
    public Blu_LevelManager lvl;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            lvl.ShowEnding();
        }
    }
}

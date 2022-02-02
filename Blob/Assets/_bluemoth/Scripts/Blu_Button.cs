using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Rewired;
using MoreMountains.CorgiEngine;

public class Blu_Button : MonoBehaviour
{
    [System.Serializable]
    public class ButtonEvent : UnityEvent { }

    public ButtonEvent buttonEvents = new ButtonEvent();

    public Player player1;
    public Player player2;


    // Start is called before the first frame update
    void Start()
    {
        player1 = ReInput.players.GetPlayer(0);
        player2 = ReInput.players.GetPlayer(1);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Entered");
        if (collision.gameObject.tag == "Player")
        {
            Character c = collision.gameObject.GetComponentInParent<Character>();
            Debug.Log("Player Entered " + c.PlayerID);
            if (c.PlayerID == "Player1")
            {
                Debug.Log("Player 1");
                if (player1.GetButtonDown("Jetpack"))
                {
                    Debug.Log("Button Pressed");
                    buttonEvents.Invoke();
                }
            } else if (c.PlayerID == "Player2")
            {
                Debug.Log("Player 2");
                if (player2.GetButtonDown("Jetpack"))
                {
                    Debug.Log("Button Pressed");
                    buttonEvents.Invoke();
                }
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public Rigidbody2D rigi;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            rigi.simulated = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            rigi.simulated = true;
    }
}

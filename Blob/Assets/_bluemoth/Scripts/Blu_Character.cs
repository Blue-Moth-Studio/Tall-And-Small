using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using System;

public class Blu_Character : MonoBehaviour
{
    private CheckPoint currentCheckpoint;
    private Animator _animator;
    private Character _character;
    public float deathDelay = 2;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _character = GetComponent<Character>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = collision.gameObject.GetComponent<CheckPoint>();
        }
    }

    public void Kill()
    {
        throw new NotImplementedException();
    }

    private void Respawn()
    {
        transform.position = currentCheckpoint.gameObject.transform.position;
        _animator.SetBool("Alive", true);
    }

    IEnumerator DelayKill()
    {
        
        _animator.SetBool("Alive", false);
        yield return new WaitForSeconds(deathDelay);
        Respawn();
    }
}

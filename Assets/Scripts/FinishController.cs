using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    private AudioSource _finishAudio;

    private void Start()
    {
        _finishAudio = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") 
        {
            _finishAudio.Play();

        }
    }

    private void CompleteLevel()
    {

    }
}

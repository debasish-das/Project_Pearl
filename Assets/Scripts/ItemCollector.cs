using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int pearlCount = 0;

    [SerializeField]
    private Text pearlText;

    [SerializeField]
    private AudioSource _collectAudio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Pearl"))
        {
            _collectAudio.Play();
            Destroy(collision.gameObject);
            pearlCount++;
            pearlText.text = "PEARL# " + pearlCount;
        }
    }
}

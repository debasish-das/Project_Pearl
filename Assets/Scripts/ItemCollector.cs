using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int pearlCount = 0;

    [SerializeField]
    private Text pearlText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Pearl"))
        {
            Destroy(collision.gameObject);
            pearlCount++;
            pearlText.text = "PEARL# " + pearlCount;
        }
    }
}

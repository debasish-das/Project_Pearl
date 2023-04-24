using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ItemCollector.collectedCherry = 0;
        ItemCollector.collectedOrange = 0;
        ItemCollector.collectedStrawberry = 0;

    }
}

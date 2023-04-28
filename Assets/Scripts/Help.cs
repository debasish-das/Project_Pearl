using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var noOfPearls = GameObject.Find("Player").GetComponent<ItemCollector>().GetNumberOfPearls().ToString();
        gameObject.GetComponent<Text>().text = "Collect " + noOfPearls + " pearls, and I will be able to make a protal for you.";
    }
}

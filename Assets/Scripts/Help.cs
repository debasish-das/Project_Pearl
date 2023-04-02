using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var item = new ItemCollector();
        gameObject.GetComponent<Text>().text = "Collect " + item.GetNumberOfPearls().ToString() + " pearls and I will be able to make a protal for you.";
    }

    // Update is called once per frame
    void Update()
    {
    }
}

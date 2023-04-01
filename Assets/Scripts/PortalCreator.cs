using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCreator : MonoBehaviour
{
    [SerializeField]
    private Transform portal;

    [SerializeField]
    private RectTransform helpPanel;

    void Start()
    {
        portal.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            var itemCollector = collision.gameObject.GetComponent<ItemCollector>();

            if (itemCollector.CollectedPearls() == itemCollector.GetNumberOfPearls())
            {
                portal.gameObject.SetActive(true);
            }
            else
            {
                helpPanel.gameObject.SetActive(true);
            }
        }
    }
}

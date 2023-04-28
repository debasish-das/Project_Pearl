using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionObject = collision.gameObject;
        if (collisionObject.CompareTag("Player"))
        {
            collisionObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var collisionObject = collision.gameObject;
        if (collisionObject.CompareTag("Player"))
        {
            collisionObject.transform.SetParent(null);
        }
    }
}

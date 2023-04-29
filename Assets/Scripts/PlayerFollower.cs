using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField]
    private float speed = 4;

    [SerializeField]
    private Transform startPoint;

    private GameObject player;
    private List<GameObject> playerShadows;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerShadows = player.GetComponent<PlayerMovement>().shadows;
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Time.deltaTime * speed;
        if (playerShadows.Count > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerShadows[0].transform.position, distance);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, distance);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PShadow"))
        {
            var instanceId = collision.gameObject.GetInstanceID();
            for (int i = 0; i < playerShadows.Count; i++)
            {
                if (instanceId == playerShadows[i].GetInstanceID())
                {
                    var obj = playerShadows[i];
                    playerShadows.RemoveAt(i);
                    Destroy(obj);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Invoke("GoToStart", 0.5f);
        }
    }

    void GoToStart()
    {
        transform.position = startPoint.position;
    }
}

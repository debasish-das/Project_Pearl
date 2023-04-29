
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    
    private int collectedPearl = 0;
    public static int collectedOrange = 0;
    public static int collectedCherry = 0;
    public static int collectedStrawberry = 0;

    [SerializeField]
    private Text pearlText;

    [SerializeField]
    private Text orangeText;

    [SerializeField]
    private Text cherryText;

    [SerializeField]
    private Text berryText;

    [SerializeField]
    private int numberOfPearls;

    [SerializeField]
    private AudioSource collectAudio;

    [SerializeField]
    private AudioSource fruitAudio;

    public int GetNumberOfPearls()
    {
        return numberOfPearls;
    }

    public int CollectedPearls()
    {
        return collectedPearl;
    }

    public void Start()
    {
        berryText.text = collectedStrawberry.ToString();
        cherryText.text = collectedCherry.ToString();
        orangeText.text = collectedOrange.ToString();
        pearlText.text = collectedPearl + "/" + numberOfPearls;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collider = collision.gameObject;
        if(collider.CompareTag("Pearl"))
        {
            collectAudio.Play();
            Destroy(collider);
            collectedPearl++;
            pearlText.text = collectedPearl + "/" + numberOfPearls;
        }
        else if (collider.CompareTag("Strawberry"))
        {
            collectItem(fruitAudio, ref collectedStrawberry, collider, berryText);
        }
        else if (collider.CompareTag("Cherry"))
        {
            collectItem(fruitAudio, ref collectedCherry, collider, cherryText);
        }
        else if (collider.CompareTag("Orange"))
        {
            collectItem(fruitAudio, ref collectedOrange, collider, orangeText);
        }
    }

    private void collectItem(AudioSource audio, ref int itemCount, GameObject item, Text countText)
    {
        audio.Play();
        itemCount++;
        Destroy(item);
        countText.text = itemCount.ToString();
    }
}

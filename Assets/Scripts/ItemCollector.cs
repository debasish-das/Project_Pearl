
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    
    private int collectedPearl = 0;
    private static int collectedOrange = 0;
    private static int collectedCherry = 0;
    private static int collectedStrawberry = 0;

    [SerializeField]
    private Text pearlText;

    [SerializeField]
    private Text orangeText;

    [SerializeField]
    private Text cherryText;

    [SerializeField]
    private Text berryText;

    [SerializeField]
    private int numberOfPearls = 10;

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

    public int CollectedOrange()
    {
        return collectedOrange;
    }

    public int CollectedCherry()
    {
        return collectedCherry;
    }

    public int CollectedStrawberry()
    {
        return collectedStrawberry;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collider = collision.gameObject;
        Debug.Log(collider.tag);
        if(collider.CompareTag("Pearl"))
        {
            collectAudio.Play();
            Destroy(collision.gameObject);
            collectedPearl++;
            pearlText.text = collectedPearl + "/" + numberOfPearls;
        }
        else if (collider.CompareTag("CP"))
        {
            collision.gameObject.GetComponent<Animator>().SetInteger("state", 1);
            collision.gameObject.tag = "Untagged";
        }
        else if (collider.CompareTag("Strawberry"))
        {
            fruitAudio.Play();
            collectedStrawberry++;
            Destroy(collision.gameObject);
            berryText.text = collectedStrawberry.ToString();
        }
        else if (collider.CompareTag("Cherry"))
        {
            fruitAudio.Play();
            collectedCherry++;
            Destroy(collision.gameObject);
            cherryText.text = collectedCherry.ToString();
        }
        else if (collider.CompareTag("Orange"))
        {
            fruitAudio.Play();
            collectedOrange++;
            Destroy(collision.gameObject);
            orangeText.text = collectedOrange.ToString();
        }
    }
}

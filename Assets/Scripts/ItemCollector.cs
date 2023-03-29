
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
        var collider = collision.gameObject;
        if(collider.CompareTag("Pearl"))
        {
            _collectAudio.Play();
            Destroy(collision.gameObject);
            pearlCount++;
            pearlText.text = "PEARL# " + pearlCount;
        }
        else if (collider.CompareTag("CP"))
        {
            collision.gameObject.GetComponent<Animator>().SetInteger("state", 1);
            collision.gameObject.tag = "Untagged";
        }
    }
}

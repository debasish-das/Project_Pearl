
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour
{
    private AudioSource _finishAudio;
    private bool _isLevelComplete = false;

    private void Start()
    {
        _finishAudio = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !_isLevelComplete)
        {
            _finishAudio.Play();
            _isLevelComplete = true;
            Invoke("CompleteLevel", 1.5f);
        }
    }

    private void CompleteLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        //Debug.Log(nextSceneIndex);

        //if (nextSceneIndex < SceneManager.sceneCount)
        //{
        SceneManager.LoadScene(nextSceneIndex);
        //}
    }
}


using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody2d;

    [SerializeField] 
    private AudioSource deathAudio;

    [SerializeField]
    private Transform checkPoint;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rigidBody2d.velocity.y < -70)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CP"))
        {
            collision.gameObject.GetComponent<Animator>().SetInteger("state", 1);
            collision.gameObject.tag = "Untagged";
            checkPoint = collision.gameObject.GetComponent<Transform>();
        }
    }

    private void Die()
    {
        deathAudio.Play();
        animator.SetTrigger("deathTrigger");
        rigidBody2d.bodyType = RigidbodyType2D.Static;
        Invoke("RestartLevel", 1.5f);
    }

    private void RestartLevel()
    {
        if (checkPoint != null)
        {
            transform.position = checkPoint.position;
            animator.SetInteger("_movementState", 10);
            rigidBody2d.bodyType = RigidbodyType2D.Dynamic;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

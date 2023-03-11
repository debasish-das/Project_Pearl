using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidBody2d;

    [SerializeField] 
    private AudioSource _deathAudio;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_rigidBody2d.velocity.y < -70)
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

    private void Die()
    {
        _deathAudio.Play();
        _animator.SetTrigger("deathTrigger");
        _rigidBody2d.bodyType = RigidbodyType2D.Static;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

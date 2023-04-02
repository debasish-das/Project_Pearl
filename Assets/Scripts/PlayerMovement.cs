
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _playerBody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;

    [SerializeField]
    private LayerMask _jumpableGround;

    [SerializeField]
    private AudioSource _jumpAudio;

    [SerializeField]
    private float jumpForce = 20f;
    [SerializeField]
    private float velocityX = 9f;

    private enum MovementState { idle = 0, running = 1, jumping = 2, falling = 3, death = 4 };

    // Start is called before the first frame update
    private void Start()
    {
        _playerBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        _playerBody.velocity = new Vector2(dirX * velocityX, _playerBody.velocity.y);


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _jumpAudio.Play();
            _playerBody.velocity = new Vector2(_playerBody.velocity.x, jumpForce);
        }

        UpdateAnimation(dirX);
    }

    private void UpdateAnimation(float dirX)
    {
        MovementState state;

        if (dirX < 0f)
        {
            state = MovementState.running;
            _spriteRenderer.flipX = true;
        }
        else if (dirX > 0f)
        {
            state = MovementState.running;
            _spriteRenderer.flipX = false;
        }
        else
        {
            state = MovementState.idle;
        }

        if (_playerBody.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (_playerBody.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        //Debug.Log(_playerBody.velocity.y);

        _animator.SetInteger("_movementState", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.down, .1f,_jumpableGround);
    }
}

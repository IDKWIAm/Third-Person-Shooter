using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public RuntimeAnimatorController animatorController;

    public float gravity = 9.8f;
    public float jumpForce = 10f;
    public float speed = 10f;

    private Vector3 _moveVector;
    private float _fallVelocity = 0f;
    private bool isRunning = false;

    private Animator _animator;
    private CharacterController _characterController;


    void Start()
    {
        InitAnimator();
        InitCharacterController();
        LockCursor();
    }
    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            Jump();
        }
    }
    void FixedUpdate()
    {
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_characterController.isGrounded)
            _fallVelocity = 0;
    }

    private void InitAnimator()
    {
        if (transform.childCount == 0) return;
        var child = transform.GetChild(0).gameObject;

        _animator = child.GetComponent<Animator>();
        if (!_animator)
            _animator = child.AddComponent<Animator>();

        _animator.runtimeAnimatorController = animatorController;
    }

    private void InitCharacterController()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Move()
    {
        _moveVector = Vector3.zero;

        isRunning = false;
        _animator?.SetFloat("X", 0);
        _animator?.SetFloat("Y", 0);

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            _animator?.SetBool("isRunning", true);
            _animator?.SetFloat("X", 0);
            _animator?.SetFloat("Y", 1);
            isRunning = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            _animator?.SetBool("isRunning", true);
            _animator?.SetFloat("X", 0);
            _animator?.SetFloat("Y", -1);
            isRunning = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            _animator?.SetBool("isRunning", true);
            _animator?.SetFloat("X", 1);
            _animator?.SetFloat("Y", 0);
            isRunning = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            _animator?.SetBool("isRunning", true);
            _animator?.SetFloat("X", -1);
            _animator?.SetFloat("Y", 0);
            isRunning = true;
        }
        
        if (!isRunning)
        {
            _animator?.SetBool("isRunning", false);
        }
    }

    private void Jump()
    {
        _fallVelocity = -jumpForce;
        _animator?.SetTrigger("Jump");
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

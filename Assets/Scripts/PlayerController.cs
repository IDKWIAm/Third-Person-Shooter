using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public RuntimeAnimatorController animatorController;

    public float gravity = 9.8f;
    public float jumpForce = 10f;
    public float speed = 10f;
    public float runMultiplier = 1f;

    public Animator aimAnimator;
    public GameObject pauseMenu;

    public GameObject wasdText;
    public GameObject runText;
    public GameObject interactText;

    private Vector3 _moveVector;
    private float _fallVelocity = 0f;
    private bool isMoving = false;

    private Animator _charAnimator;
    private CharacterController _characterController;

    private bool _walkTextChanged;
    private bool _runTextChanged;


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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenPauseMenu();
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

        _charAnimator = child.GetComponent<Animator>();
        if (!_charAnimator)
            _charAnimator = child.AddComponent<Animator>();

        _charAnimator.runtimeAnimatorController = animatorController;
    }

    private void InitCharacterController()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Move()
    {
        _moveVector = Vector3.zero;

        isMoving = false;
        _charAnimator?.SetFloat("X", 0);
        _charAnimator?.SetFloat("Y", 0);
        _charAnimator?.SetFloat("RunningOrNot", 0);

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _moveVector += transform.forward * runMultiplier;
                _charAnimator?.SetFloat("RunningOrNot", 1);

                if (runText != null && !_runTextChanged)
                {
                    runText.SetActive(false);
                    interactText.SetActive(true);
                    _runTextChanged = true;
                }
            }
            else
            {
                _moveVector += transform.forward;
                _charAnimator?.SetFloat("X", 0);
                _charAnimator?.SetFloat("Y", 1);
            }
            _charAnimator?.SetBool("isMoving", true);
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            _charAnimator?.SetBool("isMoving", true);
            _charAnimator?.SetFloat("X", 0);
            _charAnimator?.SetFloat("Y", -1);
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            _charAnimator?.SetBool("isMoving", true);
            _charAnimator?.SetFloat("X", 1);
            _charAnimator?.SetFloat("Y", 0);
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            _charAnimator?.SetBool("isMoving", true);
            _charAnimator?.SetFloat("X", -1);
            _charAnimator?.SetFloat("Y", 0);
            isMoving = true;
        }
        
        if (!isMoving)
        {
            _charAnimator?.SetBool("isMoving", false);
        } else if (wasdText != null && !_walkTextChanged)
        {
            wasdText.SetActive(false);
            runText.SetActive(true);
            _walkTextChanged = true;
        }
    }

    private void Jump()
    {
        _fallVelocity = -jumpForce;
        _charAnimator?.SetTrigger("Jump");
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OpenPauseMenu()
    {
        gameObject.GetComponent<PlayerController>().enabled = false;
        gameObject.GetComponent<CameraRotation>().enabled = false;
        gameObject.GetComponent<BulletCaster>().enabled = false;
        gameObject.GetComponent<GrenadeCaster>().enabled = false;
        pauseMenu.GetComponent<Animator>().SetTrigger("WindowAppear");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

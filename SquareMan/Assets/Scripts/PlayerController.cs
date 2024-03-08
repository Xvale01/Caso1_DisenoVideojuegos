using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float rotationSpeed;

    [SerializeField]
    float jumpForce;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    LayerMask whatIsWalkable;

    [SerializeField]
    float gravityMultiplier;

    float _inputX;
    float _inputZ;

    float _gravityY;
    float _velocityY;

    bool _isJumpPressed;
    bool _isGrounded;

    CharacterController _characterController;

    Camera _mainCamera;

    Vector3 _direction;


    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _mainCamera = Camera.main;
        _gravityY = Physics.gravity.y;
    }

    private void Start()
    {
        _isGrounded = IsGrounded();
        if (!_isGrounded)
        {
            StartCoroutine(WaitForGroundedCoroutine());
        }
    }
    public void Update()
    {
        HandleGravity();
        HandleMovement();
    }
    //update es solo para logica
    //fixedUpdate movimientos y saltos 

    private void HandleGravity()
    {
        if (_isGrounded)
        {
            if (_velocityY < -1.0F)
            {
                _velocityY = -1.0F;
            }

            HandleJump();
            if (_isJumpPressed)
            {
                Jump();
            }

        }
        else
        {
            _velocityY += _gravityY * gravityMultiplier * Time.deltaTime;
        }
    }

    private void HandleMovement()
    {
        _inputX = Input.GetAxisRaw("Horizontal");
        _inputZ = Input.GetAxisRaw("Vertical");
    }
    public void HandleJump()
    {
        _isJumpPressed = Input.GetButton("Jump");
    }
    private void FixedUpdate()
    {
        Rotate();
        Move();
    }

    private bool IsMove()
    {
        return (_inputX != 0.0F || _inputZ != 0.0F);
    }

    private void Move()
    {
        _direction.y = _velocityY;
        _characterController.Move(_direction * moveSpeed * Time.fixedDeltaTime);
    }

    private void Rotate()
    {
        if (!IsMove())
        {
            _direction = Vector3.zero;
            return;
        }

        _direction = Quaternion.Euler(0.0F, _mainCamera.transform.eulerAngles.y, 0.0F)
            * new Vector3(_inputX, 0.0F, _inputZ);
        Quaternion targetRotation = Quaternion.LookRotation(_direction, Vector3.up);
        transform.rotation =
            Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        _velocityY = jumpForce;

        _isGrounded = false;
        StartCoroutine(WaitForGroundedCoroutine());
    }

    private bool IsGrounded()
    {
        return _characterController.isGrounded;
    }

    private IEnumerator WaitForGroundedCoroutine()
    {
        yield return new WaitUntil(() => !IsGrounded());
        yield return new WaitUntil(() => IsGrounded());
        _isGrounded = true;
    }

}

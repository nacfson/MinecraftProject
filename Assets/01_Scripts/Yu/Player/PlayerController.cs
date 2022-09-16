using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 스피드 조정 변수
    [SerializeField]
    private float _runSpeed;
    private float _applySpeed;

    // 상태 변수
    private bool _isRun = false;
    [SerializeField]
    private float _walkSpeed = 3f;
    public float jumpForce = 300;
    public float timeBeforeNextJump = 1.2f;
    private float canJump = 0f;
    
    private bool _isGronded = true;
    
    private bool _isCrouch = false;

    [SerializeField]
    private float _crouchSpeed = 3f;

    private CapsuleCollider _capsuleCollider;
    //앉았응 때 얼마나 앉았을지 결정하는 변수
    [SerializeField]
    private float crouchPosY;
    private float originPosY;
    private float applyCrouchPosY;
    //카메라 변수

    [SerializeField]
    private float _lookSensitivity;


    [SerializeField]
    private float _cameraRotationLimit;
    private float _currentCameraRotationX = 0f;
    [SerializeField]
    private Camera _camera;
    Animator anim;
    Rigidbody rb;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Start()
    {
        _capsuleCollider = GetComponentInChildren<CapsuleCollider>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        _applySpeed = _walkSpeed;
        originPosY = _camera.transform.localPosition.y;
        applyCrouchPosY = originPosY;
        //_camera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        TryCrouch();
        IsGround();
        TryRun();
        TryJump();
        ControlPlayer();
        CameraRotation();
        CharacterRotation();
    }
    void TryCrouch()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
    }
    void Crouch()
    {
        _isCrouch = !_isCrouch;
        if(_isCrouch)
        {
            _applySpeed = _crouchSpeed;
            applyCrouchPosY =crouchPosY;
        }
        else
        {
            _applySpeed = _walkSpeed;
            applyCrouchPosY = originPosY;
        }
        StartCoroutine(CrouchCoroutine());

    }
    IEnumerator CrouchCoroutine()
    {
        float _posY = _camera.transform.localPosition.y;
        while(_posY != applyCrouchPosY)
        {
            _posY = Mathf.Lerp(_posY , applyCrouchPosY, 0.3f);
            _camera.transform.localPosition = new Vector3(0,_posY,0);
            yield return null;
        }
    }
    void CharacterRotation()
    {
        //좌우 캐릭터 회전
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f,_yRotation,0f) * _lookSensitivity;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(_characterRotationY));
    }

    void TryJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isGronded == true)
        {
            Jump();
        }
    }
    void Jump()
    {
        if (_isCrouch)
        {
            Crouch();
        }
        rb.velocity = transform.up * jumpForce;
    }
    
    void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * _lookSensitivity;
        _currentCameraRotationX -= _cameraRotationX;    
        _currentCameraRotationX = Mathf.Clamp(_currentCameraRotationX, -_cameraRotationLimit, _cameraRotationLimit);

        _camera.transform.localEulerAngles = new Vector3(_currentCameraRotationX,0f,0f);

    }
    void IsGround()
    {
        _isGronded = Physics.Raycast(transform.position, Vector3.down, _capsuleCollider.bounds.extents.y + 0.1f);
    }
    void TryRun()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            Running();
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            RunningCancel();
        }
    }
    void Running()
    {
        _isRun = true;
        _applySpeed = _runSpeed;
    }

    void RunningCancel()
    {
        _isRun = false;
        _applySpeed = _walkSpeed;
    }
    void ControlPlayer()
    {
        float _moveDirX = Input.GetAxis("Horizontal");
        float _moveDirZ = Input.GetAxis("Vertical");

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * _applySpeed;

        rb.MovePosition(transform.position + _velocity);


        // Vector3 movement = new Vector3(transform.forward.x * moveHorizontal, 0.0f, transform.right.z * moveVertical);
        // if (movement != Vector3.zero)
        // {
        //     transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        //     //anim.SetInteger("Walk", 1);
        // }
        // else {
        //     anim.SetInteger("Walk", 0);
        // }

        // transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        // if (Input.GetButtonDown("Jump") && Time.time > canJump)
        // {
        //         rb.AddForce(0, jumpForce, 0);
        //         canJump = Time.time + timeBeforeNextJump;
        //         anim.SetTrigger("jump");
        // }
    }
}
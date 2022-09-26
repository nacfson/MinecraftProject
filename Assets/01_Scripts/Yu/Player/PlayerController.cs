using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera Camera
    {
        get => _camera;

    }
    
    public Rigidbody PlayerRigidbody
    {
        get
        {
            return rb;
        }
    }
    // 스피드 조정 변수
    [SerializeField]
    private float _runSpeed;
    public float applySpeed;

    // 상태 변수
    private bool _isRun = false;
    public float walkSpeed = 3f;
    public float jumpForce = 300;
    public float timeBeforeNextJump = 1.2f;
    private float canJump = 0f;
    
    private bool _isGronded = true;
    

    private BoxCollider _capsuleCollider;


    Animator anim;
    public Rigidbody rb;


    public Head head;

    [SerializeField]
    private float _lookSensitivity;
        public bool IsCrouch
    {
        get
        {
            return _isCrouch;
        }
    }
        //카메라 변수



    public PlayerController playerController;

        //앉았응 때 얼마나 앉았을지 결정하는 변수
    [SerializeField]
    private float crouchPosY;
    private float originPosY;
    private float applyCrouchPosY;
    private bool _isCrouch = false;

    [SerializeField]
    private float _crouchSpeed = 3f;


    [SerializeField]
    private float _cameraRotationLimit;
    private float _currentCameraRotationX = 0f;
    [SerializeField]
    private Camera _camera;
    public RightArmController rightArmController;

    public PlayerLeftClickInteraction playerLeftClickInteraction;

    public Transform placeBlock;


    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        originPosY = _camera.transform.localPosition.y;
        applyCrouchPosY = originPosY;
        playerController = GetComponentInParent<PlayerController>();
        rightArmController = FindObjectOfType<RightArmController>();
        playerLeftClickInteraction = GetComponent<PlayerLeftClickInteraction>();


    }
    void FixedUpdate()
    {
        CharacterRotation();
        CameraRotation();


    }
    void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * _lookSensitivity;
        _currentCameraRotationX -= _cameraRotationX;    
        _currentCameraRotationX = Mathf.Clamp(_currentCameraRotationX, -_cameraRotationLimit, _cameraRotationLimit);
        _camera.transform.localEulerAngles = new Vector3(_currentCameraRotationX,0f,0f);

    }
    public void Crouch()
    {
        _isCrouch = !_isCrouch;
        if(_isCrouch)
        {
            playerController.applySpeed = _crouchSpeed;
            applyCrouchPosY =crouchPosY;
        }
        else
        {
            playerController.applySpeed = playerController.walkSpeed;
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
        playerController.PlayerRigidbody.MoveRotation(playerController.PlayerRigidbody.rotation * Quaternion.Euler(_characterRotationY));
    }
    
    void Start()
    {
        head = GetComponentInChildren<Head>();
        _capsuleCollider = GetComponentInChildren<BoxCollider>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        applySpeed = walkSpeed;
        //_camera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        TryCrouch();
        IsGround();
        TryRun();
        TryJump();
        ControlPlayer();
    }
    void TryCrouch()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
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
        if (IsCrouch)
        {
            Crouch();
            Debug.Log("Jump");
        }
        rb.velocity = transform.up * jumpForce;
    }
    

    void IsGround()
    {
        _isGronded = !Physics.Raycast(transform.position, Vector3.down, 0.1f);
        //Debug.Log(_isGronded);
        Debug.DrawRay(transform.position, Vector3.down, Color.red,0.1f);
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
        applySpeed = _runSpeed;
    }

    void RunningCancel()
    {
        _isRun = false;
        applySpeed = walkSpeed;
    }
    void ControlPlayer()
    {
        float _moveDirX = Input.GetAxis("Horizontal");
        float _moveDirZ = Input.GetAxis("Vertical");

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applySpeed;

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
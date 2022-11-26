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
    public float timeBeforeNextJump = 0.25f;
    private float   canJump = 0f;
    
    public bool _isGronded = true;
    

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

        //앉았을 때 얼마나 앉았을지 결정하는 변수
    [SerializeField]
    private float crouchPosY;
    private float originPosY;
    private float applyCrouchPosY;
    private bool _isCrouch = false;
    private bool _canCheckGround = false;

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
        
        originPosY = _camera.transform.localPosition.y;
        applyCrouchPosY = originPosY;
        _canCheckGround = true;
        playerController = GetComponentInParent<PlayerController>();
        rightArmController = FindObjectOfType<RightArmController>();
        playerLeftClickInteraction = GetComponent<PlayerLeftClickInteraction>();


    }
    void FixedUpdate()
    {
        if(InventoryUIManager.inventoryActivated == false)
        {
            CharacterRotation();
            CameraRotation();
            TryCrouch();
            IsGround();
            TryRun();
            TryJump();
            ControlPlayer();
        }



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
        if(_canCheckGround)
        {
            _isGronded = Physics.Raycast(transform.position, Vector3.down, 1f);
            StartCoroutine(GroundCor());
        }
        Debug.DrawRay(transform.position, Vector3.down, Color.red,0.1f);
    }

    IEnumerator GroundCor()
    {
        _canCheckGround = false;
        yield return new WaitForSeconds(0.1f);
        _canCheckGround = true;

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

        rb.MovePosition(transform.position + _velocity * Time.fixedDeltaTime * 45f);
    }
}
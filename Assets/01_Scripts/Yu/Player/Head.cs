using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public bool IsCrouch
    {
        get
        {
            return _isCrouch;
        }
    }
        //카메라 변수

    [SerializeField]
    private float _lookSensitivity;

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

    public Rigidbody rb;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        originPosY = _camera.transform.localPosition.y;
        applyCrouchPosY = originPosY;
        playerController = GetComponentInParent<PlayerController>();
        rightArmController = FindObjectOfType<RightArmController>();
        rb = playerController.rb;


    }
    void FixedUpdate()
    {
        CharacterRotation();
        CameraRotation();
        CheckRay();


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
    void CheckRay()
    {
        Vector3 pos = new Vector3(transform.position.x,transform.position.y + 5f, transform.position.z);   
        rightArmController.canInteract = Physics.Raycast(pos, transform.forward, 20f);
        Debug.DrawRay(pos, transform.forward * 20f, Color.green);
    }
    void CharacterRotation()
    {
        //좌우 캐릭터 회전
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f,_yRotation,0f) * _lookSensitivity;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(_characterRotationY));
    }
}

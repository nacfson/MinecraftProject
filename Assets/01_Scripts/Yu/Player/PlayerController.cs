using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
            head.Crouch();
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
        if (head.IsCrouch)
        {
            head.Crouch();
        }
        rb.velocity = transform.up * jumpForce;
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
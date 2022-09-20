using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isGrounded;
    public bool isSprinting;

    private Transform _cam;
    public float gravity = -9.8f;

    public float jumpForce = 5f;


    public float playerWidth = 0.3f;

    private float _horizontal;
    private float _vertical;
    private float _mouseHorizontal;
    private float _mouseVertical;
    private Vector3 _velocity;
    private float _verticalMomentum = 0f;
    private bool _jumpRequest;



    private void Awake()
    {
        _cam = GameObject.Find("Main Camera").transform;
    }


    private void FixedUpdate() 
    {
        GetPlayerInputs();
        _velocity = ((transform.forward * _vertical) + (transform.right * _horizontal)) * Time.fixedDeltaTime * 3f;  
        _velocity += Vector3.up * gravity * Time.fixedDeltaTime;

        //_velocity.y = CheckDoownSpeed(_velocity.y);

        transform.Rotate(Vector3.up * _mouseHorizontal);
        _cam.Rotate(Vector3.right * -_mouseVertical);
        transform.Translate(_velocity, Space.World);
    }       

    private void GetPlayerInputs()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        _mouseHorizontal = Input.GetAxisRaw("Mouse X");
        _mouseVertical = Input.GetAxisRaw("Mouse Y");

        if(Input.GetButtonDown("Sprint"))
        {
            isSprinting = true;
        }
        if(Input.GetKeyUp("Sprint"))
        {
            isSprinting = false;
        }

        if(isGrounded == false && Input.GetButtonDown("Jump"))
        {
            _jumpRequest = true;
        }

        
    }
    // private float CheckDownSpeed(float downSpeed)
    // {
    //     if(world.CheckForVoxel(transform.position.x - playerWidth,transform.position.y + downSpeed, transform.position.z - playerWidth||
    //     world.CheckForVoxel(transform.position.x + playerWidth,transform.position.y + downSpeed, transform.position.z - playerWidth||
    //     world.CheckForVoxel(transform.position.x + playerWidth,transform.position.y + downSpeed, transform.position.z + playerWidth||
    //     world.CheckForVoxel(transform.position.x - playerWidth,transform.position.y + downSpeed, transform.position.z + playerWidth||)
    //     {
    //         isGrounded = true;
    //         return 0;
    //     }
    //     else
    //     {
    //         isGrounded = false;
    //     }
    // }


    // private float CheckUpSpeed(float upSpeed)
    // {
    //     if(world.CheckForVoxel(transform.position.x - playerWidth,transform.position.y + 2f * downSpeed, transform.position.z - playerWidth||
    //     world.CheckForVoxel(transform.position.x + playerWidth,transform.position.y + 2f * downSpeed, transform.position.z - playerWidth||
    //     world.CheckForVoxel(transform.position.x + playerWidth,transform.position.y + 2f * downSpeed, transform.position.z + playerWidth||
    //     world.CheckForVoxel(transform.position.x - playerWidth,transform.position.y + 2f * downSpeed, transform.position.z + playerWidth||)
    //     {
    //         return 0;
    //     }
    //     else
    //     {
    //      return upSpeed;
    //     }
    // }

    // public bool Front
    // {
    //     get
    //     {
    //         if(world.CheckForVoxel(transform.position.x,transform.position.y,transform.position.z))
    //     }
    // }

}

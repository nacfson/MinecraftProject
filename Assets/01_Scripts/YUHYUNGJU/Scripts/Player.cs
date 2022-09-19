using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _cam;
    public float gravity = -9.8f;
    private float _horizontal;
    private float _vertical;
    private float _mouseHorizontal;
    private float _mouseVertical;
    private Vector3 _velocity;

    private void Awake()
    {
        _cam = GameObject.Find("Main Camera").transform;
    }


    private void FixedUpdate() 
    {
        GetPlayerInputs();
        _velocity = ((transform.forward * _vertical) + (transform.right * _horizontal)) * Time.deltaTime * 3f;  
        _velocity += Vector3.up * gravity * Time.deltaTime;

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
    }

}

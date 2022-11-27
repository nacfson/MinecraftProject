using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool doorOpened;
    private void Awake()
    {
        doorOpened = false;
        CloseDoor();
    }
    public void CheckDoor()
    {
        if(doorOpened)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }
    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }
    public void CloseDoor()
    {
        gameObject.SetActive(true);

    }
}

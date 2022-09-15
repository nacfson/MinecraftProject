using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArmController : MonoBehaviour
{
    [SerializeField] private GameObject _handObject;

    //우클릭을 눌렀을 떄 실행 될 코드
    public void RightClickInteract()
    {
        Debug.Log("RightClicked");
    }

    public void LeftClickInteract()
    {
        Debug.Log("LeftClicked");
    }
}

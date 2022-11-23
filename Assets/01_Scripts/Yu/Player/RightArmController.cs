using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArmController : MonoBehaviour
{
    [SerializeField] private GameObject _handObject;

    public PlayerController playerController;

    public float checkDistance;

    public bool canInteract;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
    }

    private float _checkDistance;
    //우클릭을 눌렀을 떄 실행 될 코드
    public void RightClickInteract()
    {
        if(canInteract)
        {
            Debug.Log("RightClicked");
        }
    }


    public void LeftClickInteract()
    {
        Debug.Log("LeftClicked");
    }
}

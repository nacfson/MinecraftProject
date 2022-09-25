using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRightClickInteraction : AgentInteraction
{
    private PlayerController _controller;
    public UnityEvent<GameObject> LeftClickEvent;

    [SerializeField] private GameObject _block;

    [SerializeField]
    private string _defineName;

    public Camera cam;
    RaycastHit hit;
    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
    }
    protected void Update()
    {
        CheckRay();
    }
    public override void Interact(GameObject obj)
    {
        if(CanInteract)
        {
            if(Input.GetMouseButtonDown(1))
            {
                SetBlock();
            }

            
        }
    }
    protected override void CheckCanInteract()
    {
        
    }

    void SetBlock()
    {
        Vector3 temp = hit.collider.transform.position;
        
        Vector3 pos = new Vector3(temp.x,temp.y + 10f,temp.z);
        Instantiate(_block,pos,Quaternion.identity);
        Debug.Log("SetBlock");


    }

    public void CheckGameObject(GameObject obj)
    {
        Interact(obj);
    }
    public override void CheckRay()
    {
        
        Vector3 pos = new Vector3(_controller.transform.position.x,_controller.transform.position.y + 10f, _controller.transform.position.z); 
        CanInteract = Physics.Raycast(pos,_controller.Camera.transform.forward ,out hit, 40f);
        if(CanInteract)
        {
            CheckGameObject(hit.collider.gameObject);
        }
        Debug.DrawRay(pos, _controller.Camera.transform.forward* 40f, Color.green);
    }
}

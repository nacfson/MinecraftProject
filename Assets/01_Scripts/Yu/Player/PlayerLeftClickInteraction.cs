using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLeftClickInteraction : AgentInteraction
{
    private PlayerController _controller;
    public UnityEvent<GameObject> LeftClickEvent;

    [SerializeField]
    private string _defineName;
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
            if(obj.tag == _defineName)
            {
                if(Input.GetMouseButton(0))
                {
                    obj.GetComponent<Block>().Mining();
                }
            }

            
        }
    }
    protected override void CheckCanInteract()
    {
        
    }

    public void CheckGameObject(GameObject obj)
    {
        Interact(obj);
    }
    public override void CheckRay()
    {
        RaycastHit hit;
        Vector3 pos = new Vector3(_controller.transform.position.x,_controller.transform.position.y + 1f, _controller.transform.position.z); 
        Ray ray = new Ray(pos, _controller.Camera.transform.forward);
        CanInteract = Physics.Raycast(pos,_controller.Camera.transform.forward ,out hit, 4f);
        if(CanInteract)
        {
            CheckGameObject(hit.collider.gameObject);

        }


        
        //Debug.DrawRay(pos, _controller.Camera.transform.forward* 40f, Color.green);
    }
}

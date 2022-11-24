using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLeftClickInteraction : AgentInteraction
{
    private PlayerController _controller;
    public UnityEvent<GameObject> LeftClickEvent;
    public InventoryUIManager inventoryUIManager;

    private GameObject _interactedObject;
    public bool canHit;
    [SerializeField]
    private float _hitDelay = 10f;
    [SerializeField]
    private string _defineName;
    [SerializeField]
    private LayerMask _layerMask;
    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        inventoryUIManager = FindObjectOfType<InventoryUIManager>();
        canHit = true;
    }
    protected void Update()
    {
        CheckRay();
    }
    public override void Interact(GameObject obj)
    {
        if (CanInteract)
        {
            if (obj.tag == "BLOCK" && InventoryUIManager.inventoryActivated == false)
            {
                if (Input.GetMouseButton(0))
                {
                    obj.GetComponent<Block>().Mining(CheckUsingTool(obj), inventoryUIManager);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    obj.GetComponent<Block>().HPReset();
                }
                if (CanInteract == false)
                {
                    obj.GetComponent<Block>().HPReset();
                }
            }
            else if (obj.tag == "CANHIT" && InventoryUIManager.inventoryActivated == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if(canHit)
                    {
                        obj.GetComponent<AgentHP>().Damaged(CheckUsingSword(obj),obj);
                        StartCoroutine(HitCor());
                    }
                }
            }
        }
    }
    IEnumerator HitCor()
    {
        canHit = false;
        yield return new WaitForSeconds(_hitDelay);
        canHit = true;
        StopCoroutine(HitCor());
    }
    public float CheckUsingTool(GameObject obj)
    {
        if (inventoryUIManager.droppableList[inventoryUIManager.buttonCount - 1].slot.item == null)
        {
            // if()
            // {

            // }
            return 1f;
        }
        else if (inventoryUIManager.droppableList[inventoryUIManager.buttonCount - 1].slot.item.tool == obj.GetComponent<Block>().blockData.item.tool)
        {
            if (inventoryUIManager.droppableList[inventoryUIManager.buttonCount - 1].slot.item.itemLevel == 0) return 1f;
            return inventoryUIManager.droppableList[inventoryUIManager.buttonCount - 1].slot.item.itemLevel;
        }
        else
        {
            return 1f;
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
        Vector3 pos = new Vector3(_controller.transform.position.x, _controller.transform.position.y + 1.5f, _controller.transform.position.z);
        Ray ray = new Ray(pos, _controller.Camera.transform.forward);
        CanInteract = Physics.Raycast(pos, _controller.Camera.transform.forward, out hit, 7f,_layerMask);
        //if(hit.collider.gameObject != null)
        //{
        //    Debug.Log(hit.collider.gameObject);

        //}
        if (CanInteract)
        {
            CheckGameObject(hit.collider.gameObject);
            
            _interactedObject = hit.collider.gameObject;

            //StartCoroutine(HitCor(_interactedObject));
        }
        //Debug.DrawRay(pos, _controller.Camera.transform.forward* 40f, Color.green);
    }

    public float CheckUsingSword(GameObject obj)
    {
        if(inventoryUIManager.droppableList[inventoryUIManager.buttonCount - 1].slot.item == null)
        {
            return 1f;
        }
        else if(inventoryUIManager.droppableList[inventoryUIManager.buttonCount - 1].slot.item.tool == ETool.Sword)
        {
            if (inventoryUIManager.droppableList[inventoryUIManager.buttonCount - 1].slot.item.itemLevel == 0) return 1f;

            return inventoryUIManager.droppableList[inventoryUIManager.buttonCount - 1].slot.item.itemLevel;
        }
        else
        {
            return 1f;
        }
    }

    //IEnumerator HitCor(GameObject obj)
    //{
    //    while(CanInteract)
    //    { 
    //        if(obj.tag =="CANHIT" && InventoryUIManager.inventoryActivated == false)
    //        {
    //            if(Input.GetMouseButtonDown(0))
    //            {
    //                obj.GetComponent<AgentHP>().Damaged(CheckUsingSword(obj));
    //            }
    //        }
    //        yield return null;
    //    }
    //}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRightClickInteraction : AgentInteraction
{
    private PlayerController _controller;
 
    [SerializeField] private GameObject _block;

    public float blockSize = 1f;
    public InventoryUIManager inventoryUIManager;
    

    [SerializeField]
    private string _defineName;

    public Camera cam;
    RaycastHit hit;
    RaycastHit originHit;
    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        inventoryUIManager = FindObjectOfType<InventoryUIManager>();
    }
    protected void Update()
    {
        CheckRay();
    }
    public override void Interact(GameObject obj)
    {
        if (CanInteract)
        {
            if (Input.GetMouseButtonDown(1))
            {
                //SetBlock();
            }
        }
    }
    protected override void CheckCanInteract()
    {

    }

    void SetBlock(Vector3 vector, Vector3 vector2)
    {
        Debug.Log($"directionVector3 : {vector}, vector2 : {vector2}");
        Vector3 newPos = vector2 + vector;
        UseItem(newPos);
    }
    void UseItem(Vector3 newPos)
    {
        Slot itemData = inventoryUIManager.slotList[inventoryUIManager.buttonCount -1].gameObject.transform.GetChild(0).GetComponent<Slot>();
        Debug.Log(itemData.item);
        if(itemData.item != null)
        {
            if(itemData.item.itemType == ItemType.Block && itemData.itemCount > 0)
            {
                Instantiate(itemData.item.itemPrefab,newPos,Quaternion.identity);
                itemData.SetSlotCount(-1);
            }
        }
    }

    public void CheckGameObject(GameObject obj)
    {
        Interact(obj);
        
    }
    public override void CheckRay()
    {
        int layerMask = (-1) - (1 << LayerMask.NameToLayer("Player"));
        Vector3 pos = new Vector3(_controller.transform.position.x, _controller.transform.position.y + 1.5f, _controller.transform.position.z);
        Ray ray = new Ray(pos, _controller.Camera.transform.forward);
        Debug.DrawRay(pos, _controller.Camera.transform.forward * 7f, Color.green);
        if (Physics.Raycast(ray, out hit, 7f, layerMask))
        {
            Physics.Raycast(ray, out originHit, 7f, layerMask);
            Vector3 directionVector3 = (hit.transform.position - ray.GetPoint(hit.distance));
            Vector3 dir = originHit.collider.transform.position;
            if (Input.GetMouseButtonDown(1) && InventoryUIManager.inventoryActivated == false)
            {
                //Debug.Log($"directionVector3 :{directionVector3}");
                CheckBigger(directionVector3.x, directionVector3.y, directionVector3.z, dir);

            }
        }

    }
    void CheckBigger(float x, float y, float z, Vector3 originVector)
    {
        if (Mathf.Abs(x) > Mathf.Abs(y) && Mathf.Abs(x) > Mathf.Abs(z))
        {
            if (x < 0f)
            {
                SetBlock(new Vector3(1, 0, 0), originVector);

            }
            else
            {
                SetBlock(new Vector3(-1, 0, 0), originVector);

            }
        }
        else if (Mathf.Abs(y) > Mathf.Abs(x) && Mathf.Abs(y) > Mathf.Abs(z))
        {
            if (y < 0f)
            {

                SetBlock(new Vector3(0, 1, 0), originVector);
            }
            else
            {
                SetBlock(new Vector3(0, -1, 0), originVector);

            }
        }
        else if (Mathf.Abs(z) > Mathf.Abs(y) && Mathf.Abs(z) > Mathf.Abs(x))
        {
            if (z < 0f)
            {

                SetBlock(new Vector3(0, 0, 1), originVector);
            }
            else
            {
                SetBlock(new Vector3(0, 0, -1), originVector);

            }

        }

    }
}

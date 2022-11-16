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
    public World world;
    

    [SerializeField]
    private string _defineName;

    public Camera cam;

    public Transform camTransform;
    RaycastHit hit;
    RaycastHit originHit;

    public float checkIncrement = 0.1f;
    public float reach = 7f;

    public Transform highlightBlock;
    public Transform placeBlock;
    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        inventoryUIManager = FindObjectOfType<InventoryUIManager>();
        world = GameObject.Find("World").GetComponent<World>();
    }
    protected void Update()
    {
        CheckRay();
    }
    private void placeCursorBlocks () {

        float step = checkIncrement;
        Vector3 lastPos = new Vector3();

        while (step < reach) {

            Vector3 pos = cam.transform.position + (cam.transform.forward * step);

            if (world.CheckForVoxel(pos)) {

                highlightBlock.position = new Vector3(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y), Mathf.FloorToInt(pos.z));
                placeBlock.position = lastPos;

                highlightBlock.gameObject.SetActive(true);
                placeBlock.gameObject.SetActive(true);

                return;

            }

            lastPos = new Vector3(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y), Mathf.FloorToInt(pos.z));

            step += checkIncrement;

        }

        highlightBlock.gameObject.SetActive(false);
        placeBlock.gameObject.SetActive(false);

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
        //Debug.Log($"directionVector3 : {vector}, vector2 : {vector2}");
        Vector3 newPos = vector2 + vector;
        UseItem(newPos);
    }
    void UseItem(Vector3 newPos)
    {
        Slot itemData = inventoryUIManager.slotList[inventoryUIManager.buttonCount -1].gameObject.transform.GetChild(0).GetComponent<Slot>();
        //Debug.Log(itemData.item);
        if(itemData.item != null)
        { 
            //itemData.item.itemType == ItemType.Block && 
            if (itemData.itemCount > 0)
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

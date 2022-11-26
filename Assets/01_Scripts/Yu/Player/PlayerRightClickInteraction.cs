using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRightClickInteraction : AgentInteraction
{
    private PlayerController _controller;
    [SerializeField]
    private Transform _layStartTrm = null;
 
    [SerializeField] private GameObject _block;
    private GameObject _player;

    public float blockSize = 1f;
    public InventoryUIManager inventoryUIManager;
    //public World world;
    public GameObject blockParent;
    

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

    public byte selectedBlockIndex = 1;
    private void Awake()
    {
        _player ??= GameObject.FindGameObjectWithTag("Player");
        cam = _player.GetComponentInChildren<Camera>();
        camTransform = cam.transform;
        _controller = GetComponent<PlayerController>();
        inventoryUIManager = FindObjectOfType<InventoryUIManager>();
        blockParent = FindObjectOfType<BlockSpawner>().gameObject;
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
        Vector3 newPos = vector2 + vector;
        UseItem(newPos,vector);
    }


    void UseItem(Vector3 newPos,Vector3 direction)
    {
        Slot itemData = inventoryUIManager.droppableList[inventoryUIManager.buttonCount -1].slot;
        if(itemData.item != null)
        { 
            //&& 
            if (itemData.itemCount > 0 && itemData.item.itemType == ItemType.Block)
            {

                if(Physics.Raycast(newPos, (_layStartTrm.position - newPos).normalized, 0.5f, 1 << 3))
                {
                    Debug.LogError("부딫");
                    return;
                }   


                Block block = Instantiate(itemData.item.itemPrefab,newPos,Quaternion.identity).GetComponent<Block>();
                block.blockData.item = itemData.item;
                block.blockData.blockPos = newPos; 

                
                if(block.blockData.item.miningClipName != "")
                {
                    SoundManager.instance.SFXPlay("MakingSound",block.blockData.item.miningClipName);
                }
        
                block.Init();
                block.transform.SetParent(blockParent.transform);
                itemData.SetSlotCount(-1);
            }
        }
    }

    public void CheckGameObject(GameObject obj)
    {
        Interact(obj);
        
    }
    // bool CheckIsItPlayer(float ff,Vector3 originVector)
    // {

        
    // }
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

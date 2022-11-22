using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    [SerializeField]
    private float _pickUpRange;
    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField]
    private InventoryUIManager _inventoryUIManager;
    private void Update()
    {
        GetItems();
    }
    void GetItems()
    {
        Collider[] collidersList = Physics.OverlapSphere(transform.position,_pickUpRange);
        foreach(var item in collidersList)
        {
            if(item.gameObject.CompareTag("ITEM"))
            {
                ItemPickUp itemPickUp = item.gameObject.GetComponent<ItemPickUp>();
                itemPickUp.transform.position = Vector3.Lerp(itemPickUp.transform.position,transform.position,Time.deltaTime);
                if(Vector3.Distance(transform.position,itemPickUp.transform.position) < 1.5f)
                {
                    AcquireItem(itemPickUp);
                } 
            }
        }
    }
    public void AcquireItem(ItemPickUp itemPickUp)
    {
        _inventoryUIManager.AcquireItem(itemPickUp.item,1);
        Destroy(itemPickUp.gameObject);
    }


}

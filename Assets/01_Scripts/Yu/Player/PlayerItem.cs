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
                //Vector3.Lerp(itemPickUp.gameObject.transform.position,  transform.position,0f);
                _inventoryUIManager.AcquireItem(itemPickUp.item,1);
                Destroy(itemPickUp.gameObject);
            }
        }
    }


}

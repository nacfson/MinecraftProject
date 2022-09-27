using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private InventorySO _inventorySO;
    public InventoryUIManager inventoryUIManager;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        inventoryUIManager = GameObject.Find("InventoryUIManager").GetComponent<InventoryUIManager>();
    }

}

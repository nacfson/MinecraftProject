using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainPanel;
    [SerializeField]
    private GameObject _toolBar;
    [SerializeField]
    private GameObject _inventoryPanel;

    public List<GameObject> toolBarList = new List<GameObject>();

    private void Awake()
    {
        _inventoryPanel.SetActive(false);
    }
}

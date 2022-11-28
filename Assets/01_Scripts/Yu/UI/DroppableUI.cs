using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DroppableUI : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{

    public InventoryUIManager InventoryUIManager
    {
        get
        {
            _inventoryUIManager = FindObjectOfType<InventoryUIManager>();
            return _inventoryUIManager;
        }
    }

    private Image image;
    private RectTransform rect;

    private InventoryUIManager _inventoryUIManager;

    public Slot slot;

    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        slot = GetComponentInChildren<Slot>();
        //GetComponentSlot();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        // 아이템 슬롯 색상 변경
        image.color = Color.yellow;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        // 아이템 슬롯 색상 변경 빠져나갔을 때
        image.color = Color.white;
    }
    public void GetComponentSlot()
    {
        for (int i = 0; i < InventoryUIManager.droppableList.Count; i++)
        {
            InventoryUIManager.droppableList[i].slot = GetComponentInChildren<Slot>();
        }

    }




    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("AA");
            Transform agoParent = eventData.pointerDrag.transform.parent;

            eventData.pointerDrag.transform.SetParent(transform);

            Transform currentSlot = transform.GetChild(0);
            Transform nextSlot = transform.GetChild(1);

            SSSS slotTemp = /*currentSlot.GetComponent<Slot>().slotSO*/ new SSSS
            {
                item = currentSlot.GetComponent<Slot>().slotSO.item,
                itemCount = currentSlot.GetComponent<Slot>().slotSO.itemCount
            };
            SSSS slotddddTemp = new SSSS
            {
                item = nextSlot.GetComponent<Slot>().slotSO.item,
                itemCount = nextSlot.GetComponent<Slot>().slotSO.itemCount
            };

            currentSlot.GetComponent<Slot>().SetSlotSOA(slotddddTemp);
            nextSlot.GetComponent<Slot>().SetSlotSOA(slotTemp);
            nextSlot.transform.SetParent(agoParent);

            //if (InventoryUIManager.droppableList[i].transform.childCount == 0)
            //{
            //    Transform tr = eventData.pointerDrag.transform.parent.GetChild(0).transform;
            //    tr.SetParent(InventoryUIManager.droppableList[i].gameObject.transform);
            //    tr.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            //    //GetComponentSlot();
            //    tr.GetComponent<Slot>().SetSlotSO(InventoryUIManager.droppableList[i].transform.GetComponent<Slot>().slotSO);
            //    InventoryUIManager.droppableList[i].transform.GetComponent<Slot>().SetSlotSO(null);
            //    return;
            //}
            //else
            //{

            //}


        }
    }

}


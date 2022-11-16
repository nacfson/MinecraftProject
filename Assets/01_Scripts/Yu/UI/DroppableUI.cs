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

	private	Image			image;
	private	RectTransform	rect;

	private InventoryUIManager _inventoryUIManager;

	public Slot slot;

	private void Awake()
	{
		image	= GetComponent<Image>();
		rect	= GetComponent<RectTransform>();
		slot = GetComponentInChildren<Slot>();
	}


	public void OnPointerEnter(PointerEventData eventData)
	{
		// 아이템 슬롯 색상 변경
		image.color = Color.white;
	}


	public void OnPointerExit(PointerEventData eventData)
	{
		// 아이템 슬롯 색상 변경 빠져나갔을 때
		image.color = Color.white;
	}


	public void OnDrop(PointerEventData eventData)
	{
		if( eventData.pointerDrag != null)
		{
			eventData.pointerDrag.transform.SetParent(transform);
			eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
			// for(int j= 0 ; j< InventoryUIManager.slotList.Count ;j++ )
			// {
			// 	if(InventoryUIManager.slotList[j].transform.childCount == 2)
			// 	{
			// 		if(InventoryUIManager.slotList[j].transform.GetChild(0).GetComponent<Slot>().item!= null &&
			// 		InventoryUIManager.slotList[j].transform.GetChild(1).GetComponent<Slot>().item!= null)
			// 		{
			// 			if(InventoryUIManager.slotList[j].transform.GetChild(0).GetComponent<Slot>().item == InventoryUIManager.slotList[j].transform.GetChild(1).GetComponent<Slot>().item)
			// 			{
			// 				InventoryUIManager.slotList[j].transform.GetChild(0).GetComponent<Slot>().AddItem(InventoryUIManager.slotList[j].transform.GetChild(0).GetComponent<Slot>().item,InventoryUIManager.slotList[j].transform.GetChild(1).GetComponent<Slot>().itemCount);
			// 				InventoryUIManager.slotList[j].transform.GetChild(1).GetComponent<Slot>().SetSlotCount(InventoryUIManager.slotList[j].transform.GetChild(1).GetComponent<Slot>().itemCount);
			// 			}
			// 		}
			// 		return;
			// 	}
			// }
			for(int i= 0 ; i< InventoryUIManager.slotList.Count ;i++ )
			{
				if(InventoryUIManager.slotList[i].transform.childCount == 0)
				{
					Transform tr = eventData.pointerDrag.transform.parent.GetChild(0).transform; 
					tr.SetParent(InventoryUIManager.slotList[i].gameObject.transform);
					tr.GetComponent<RectTransform>().anchoredPosition = Vector3.zero; //transform.GetComponentInParent<DroppableUI>().rect.position;
					return;
				}
			}

			
		}
	}

}


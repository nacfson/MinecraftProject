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

	private Slot _slot;

	private void Awake()
	{
		image	= GetComponent<Image>();
		rect	= GetComponent<RectTransform>();
		_slot = GetComponent<Slot>();
	}

	/// <summary>
	/// ���콺 ����Ʈ�� ���� ������ ���� ���� ���η� �� �� 1ȸ ȣ��
	/// </summary>
	public void OnPointerEnter(PointerEventData eventData)
	{
		// 아이템 슬롯 색상 변경
		image.color = Color.white;
	}

	/// <summary>
	/// ���콺 ����Ʈ�� ���� ������ ���� ������ �������� �� 1ȸ ȣ��
	/// </summary>
	public void OnPointerExit(PointerEventData eventData)
	{
		// 아이템 슬롯 색상 변경 빠져나갔을 때
		image.color = Color.white;
	}

	/// <summary>
	/// ���� ������ ���� ���� ���ο��� ����� ���� �� 1ȸ ȣ��
	/// </summary>
	public void OnDrop(PointerEventData eventData)
	{
		// pointerDrag�� ���� �巡���ϰ� �ִ� ���(=������)
		if ( eventData.pointerDrag != null )
		{
			eventData.pointerDrag.transform.SetParent(transform);
			eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
			for(int i= 0 ; i<InventoryUIManager.slotList.Count ;i++ )
			{
				if(InventoryUIManager.slotList[i].transform.childCount == 0)
				{
					eventData.pointerDrag.transform.parent.GetChild(0).transform.SetParent(InventoryUIManager.slotList[i].gameObject.transform);
				}
			}
		}
	}
}


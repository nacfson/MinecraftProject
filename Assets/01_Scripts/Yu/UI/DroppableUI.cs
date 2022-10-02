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

	public Slot slot;

	private InventoryUIManager _inventoryUIManager;



	private void Awake()
	{
		image	= GetComponent<Image>();
		rect	= GetComponent<RectTransform>();
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
			// �巡���ϰ� �ִ� ����� �θ� ���� ������Ʈ�� �����ϰ�, ��ġ�� ���� ������Ʈ ��ġ�� �����ϰ� ����
			eventData.pointerDrag.transform.SetParent(transform);

			eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
			Item itemData = eventData.pointerDrag.GetComponent<Slot>().item;
			for(int i= 0; i < InventoryUIManager.inventorySO.inventoryList.Count; i++)
			{
				Debug.Log("Ohnojo");
				if(rect.position == InventoryUIManager.inventorySO.inventoryList[i].rect.position)
				{
					Debug.Log($"Success : {i}번째 리스트와 같은 포지션");
					Slot tempItem = InventoryUIManager.inventorySO.inventoryList[i];
					InventoryUIManager.inventorySO.inventoryList[i].item = itemData;
					Debug.Log(itemData + "dddd");
					itemData = tempItem.item;
					break;
				}
			}
		}
	}
}


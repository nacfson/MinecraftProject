using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler, IPointerClickHandler
{
    private Transform _canvas;
    private Transform _previousParent;
    private RectTransform _rect;
    private CanvasGroup _canvasGroup;
    private InventoryUIManager _inventoryUIManager;
    private Slot _slot;
    public bool isClicked;
    public InventoryUIManager InventoryUIManager
    
	{
		get
		{
			_inventoryUIManager = FindObjectOfType<InventoryUIManager>();
			return _inventoryUIManager;
		}
	}
    void Awake()
    {
        _canvas = FindObjectOfType<Canvas>().transform;
        _rect = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _slot = GetComponent<Slot>();
        isClicked = false;
    }
    //현재 오브젝트를 드래그하기 시작할 때 1회 호출
    public void OnBeginDrag(PointerEventData ped)
    {

    }
    public void OnPointerClick(PointerEventData ped)
    {
        Debug.Log("ssss");
        EndClick(ped);
        _previousParent = transform.parent;

        transform.SetParent(_canvas);
        transform.SetAsLastSibling();

        _canvasGroup.alpha = 0.6f;
        _canvasGroup.blocksRaycasts = false;
        StartCoroutine(ChaseMousePointer(ped));
    }
    public void EndClick(PointerEventData ped)
    {
        if(Input.GetMouseButton(0) && isClicked ==true)
        {
            OnEndDrag(ped);
            StopCoroutine(ChaseMousePointer(ped));
            isClicked = false;
        }
    }
    public void OnDrag(PointerEventData ped)
    {

    }
    public void OnEndDrag(PointerEventData ped)
    {
        if(transform.parent == _canvas)
        {
            transform.SetParent(_previousParent);
            _rect.position = _previousParent.GetComponent<RectTransform>().position;
        }
        _canvasGroup.alpha = 1.0f;
        _canvasGroup.blocksRaycasts = true;
    }
    IEnumerator ChaseMousePointer(PointerEventData ped)
    {
        isClicked = true;
        while(true)
        {
            _rect.position = ped.position;
            yield return null;
        }

    }
}

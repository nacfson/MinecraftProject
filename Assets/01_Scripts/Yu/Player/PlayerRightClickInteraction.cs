using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRightClickInteraction : AgentInteraction
{
    private PlayerController _controller;

    [SerializeField] private GameObject _block;
    public float blockSize = 1f;



    [SerializeField]
    private string _defineName;

    public Camera cam;
    RaycastHit hit;
    RaycastHit origitHit;
    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
    }
    protected void Update()
    {
        CheckRay();
    }
    public override void Interact(GameObject obj)
    {
        if(CanInteract)
        {
            if(Input.GetMouseButtonDown(1))
            {
                //SetBlock();
            }

            
        }
    }
    protected override void CheckCanInteract()
    {
        
    }

    void SetBlock(Vector3 vector,Vector3 vector2)
    {
        //Vector3 temp = hit.transform.position;
        //Vector3 pos = new Vector3(temp.x,temp.y + UnityEditor.EditorSnapSettings.move.y,temp.z);
        Vector3 newPos = vector2 + vector * blockSize;
        Instantiate(_block,  newPos,Quaternion.identity);
    }

    public void CheckGameObject(GameObject obj)
    {
        Interact(obj);
    }
    public override void CheckRay()
    {
        int layerMask = (-1) - (1 << LayerMask.NameToLayer("Player"));
        Vector3 pos = new Vector3(_controller.transform.position.x  ,_controller.transform.position.y + 1f , _controller.transform.position.z);
        Ray ray = new Ray(pos,_controller.Camera.transform.forward);
        Physics.Raycast(ray, out origitHit,4f,layerMask);
        Debug.DrawRay(pos,_controller.Camera.transform.forward * 4f, Color.green);
        if(Physics.Raycast(ray, out hit,4f,layerMask))
        {
            Debug.Log(hit.transform.position);
            Vector3 directionVector3 = hit.transform.position - ray.GetPoint(hit.distance);
            Vector3 dir = origitHit.collider.transform.position;
            if(Input.GetMouseButtonDown(1))
            {

            }
        }
        //CanInteract = Physics.Raycast(pos,_controller.Camera.transform.forward ,out hit, 40f,layerMask);

        // Debug.DrawRay(pos, _controller.Camera.transform.forward * 40f, Color.green);
        // if(CanInteract)
        // {
        //     CheckGameObject(hit.collider.gameObject);
        // }
        // Ray ray = new Ray(pos, _controller.Camera.transform.forward);
        // RaycastHit raycastHit;
        // if (Physics.Raycast(ray, out raycastHit))
        // {
        //     Vector3 directionVector = raycastHit.transform.position - ray.GetPoint(raycastHit.distance);
        //     directionVector *= -2; //���⺤�Ϳ��� Ư�� �� ���� �ٶ󺸰� �ִ� ���� ���� 0.5�� �����Ƿ� �������� int������ ���ֹ����� ����
        //     Vector3 blockDirectionVector = new Vector3((int)directionVector.x, (int)directionVector.y, (int)directionVector.z);
        //     //blockDirectionVector = blockDirectionVector.normalized;
        //     blockDirectionVector *= blockSize;
        //     Debug.Log(blockDirectionVector);
        //     if(Input.GetMouseButtonDown(1))
        //     {
        //         SetBlock(blockDirectionVector);

        //     }
        //     //기존 블럭 위치 + 저거 방햑베터 * 블록사이즈
        //     //0,0,0 ���� ���� �ִµ� �׷� ���� �ٸ� �ڷ� �����ؼ� ���ֺ��� �ٶ�
        // }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRightClickInteraction : AgentInteraction
{
    private PlayerController _controller;

    [SerializeField] private GameObject _block;

    public float blockSize = 10f;


    [SerializeField]
    private string _defineName;

    public Camera cam;
    RaycastHit hit;
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

    }
    protected override void CheckCanInteract()
    {
        
    }

    void SetBlock(Vector3 vector)
    {
        //Vector3 temp = hit.transform.position;
        //Vector3 pos = new Vector3(temp.x,temp.y + UnityEditor.EditorSnapSettings.move.y,temp.z);
        Instantiate(_block,vector,Quaternion.identity);
        Debug.Log("SetBlock");
    }

    public void CheckGameObject(Vector3 vector)
    {
            if(Input.GetMouseButtonDown(1))
            {
                SetBlock(vector);
            }
    }
    public override void CheckRay()
    {
        int layerMask = (-1) - (1 << LayerMask.NameToLayer("Player"));
        // Vector3 pos = new Vector3(_controller.transform.position.x  ,_controller.transform.position.y + 10f , _controller.transform.position.z); 
        // CanInteract = Physics.Raycast(pos,_controller.Camera.transform.forward ,out hit, 40f,layerMask);
        // Debug.DrawRay(pos, _controller.Camera.transform.forward * 40f, Color.green);

        Ray ray = new Ray(pos, _controller.Camera.transform.forward);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit))
        {
            Vector3 directionVector = raycastHit.transform.position - ray.GetPoint(raycastHit.distance);
            directionVector *= -2; //���⺤�Ϳ��� Ư�� �� ���� �ٶ󺸰� �ִ� ���� ���� 0.5�� �����Ƿ� �������� int������ ���ֹ����� ����
            Vector3 blockDirectionVector = new Vector3((int)directionVector.x, (int)directionVector.y, (int)directionVector.z);
            blockDirectionVector *= blockSize;
            CheckGameObject(blockDirectionVector);
            Debug.Log(blockDirectionVector);

        
        }
        // if(CanInteract)
        // {
        //     CheckGameObject(hit.collider.gameObject);
        // }
    }
}

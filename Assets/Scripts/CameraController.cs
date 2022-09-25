using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCameraController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    public float speed = 5f;
    public float blockSize = 1f;

    private void LateUpdate()
    {
        Move();
        Rotate();

        if (Input.GetMouseButtonDown(0))
        {
            Click();
        }
    }

    private void Rotate()
    {
        transform.LookAt(target.transform.position);
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 moveVec = transform.position;
        Vector3 rightVec = x * speed * Time.deltaTime * transform.right;
        Vector3 upVec = y * speed * Time.deltaTime * transform.up;
        moveVec += rightVec;
        moveVec += upVec;

        transform.position = moveVec;
    }

    private void Click()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit))
        {
            Vector3 directionVector = raycastHit.transform.position - ray.GetPoint(raycastHit.distance);
            directionVector *= -2; //���⺤�Ϳ��� Ư�� �� ���� �ٶ󺸰� �ִ� ���� ���� 0.5�� �����Ƿ� �������� int������ ���ֹ����� ����
            Vector3 blockDirectionVector = new Vector3((int)directionVector.x, (int)directionVector.y, (int)directionVector.z);
            blockDirectionVector *= blockSize;
            Debug.Log(blockDirectionVector);

            //0,0,0 ���� ���� �ִµ� �׷� ���� �ٸ� �ڷ� �����ؼ� ���ֺ��� �ٶ�
        }
    }
}
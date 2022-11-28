using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewAngle : MonoBehaviour
{
    [SerializeField] private float viewAngle;
    [SerializeField] private float viewDistance;
    [SerializeField] private LayerMask targetMask;

    public GameObject thePlayer;
    void Start(){
    }
    public Vector3 GetTargetPos(){
        return thePlayer.transform.position;
    }

    private Vector3 BoundaryAngle(float _angle){
        _angle += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(_angle * Mathf.Deg2Rad), 0f, Mathf.Cos(_angle * Mathf.Deg2Rad));
    }

    public bool View(){
        if(GetComponent<Distance>().Dist <=3){
            return true;
        }
        // Vector3 _leftBoundary = BoundaryAngle(-viewAngle * 0.5f);
        // Vector3 _rightBoundary = BoundaryAngle(viewAngle * 0.5f);
        // Debug.DrawRay(transform.position + transform.up, _leftBoundary, Color.red);
        // Debug.DrawRay(transform.position + transform.up, _rightBoundary, Color.red);
        // Collider[] _target = Physics.OverlapSphere(transform.position, viewDistance, targetMask);

        // for(int i = 0; i < _target.Length; i++){
        //     Transform _targetTf = _target[i].transform;
        //     if(_targetTf.tag == "Player"){
        //         Vector3 _direction = (_targetTf.position - transform.position).normalized;
        //         float _angle = Vector3.Angle(_direction, transform.forward);

        //         if(_angle < viewAngle * 0.5f){
        //             RaycastHit _hit;
        //             if(Physics.Raycast(transform.position + transform.up, _direction, out _hit, viewDistance)){
        //                 if(_hit.transform.name == "Player"){
        //                     Debug.Log("플레이어가 돼지 시야 내에 있습니다");
        //                     Debug.DrawRay(transform.position + transform.up, _direction, Color.blue);
        //                     return true;
        //                 }
        //             }
        //         }
        //     }
        // }
        return false;
    }
}

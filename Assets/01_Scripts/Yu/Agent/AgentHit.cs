using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentHit : MonoBehaviour
{
    private Transform _target;
    [SerializeField]
    private float _hitDistance = 2f;
    [SerializeField]
    private float _damage;


    void Hit()
    {
        if(CanHit())
        {
            _target.GetComponent<AgentHP>().Damaged(_damage,this.gameObject);
        }
    }
    bool CanHit()
    {
        if(Vector3.Distance(transform.position,_target.position) < _hitDistance)
        {
            return true;
        }
        return false;
    }
}

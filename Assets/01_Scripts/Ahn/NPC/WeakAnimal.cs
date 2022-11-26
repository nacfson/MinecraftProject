using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakAnimal : Animal
{
    public void Run(Vector3 _targetPos)
    {
        direction = Quaternion.LookRotation(transform.position - _targetPos).eulerAngles;

        currentTime = runTime;
        isWalking = false;
        isRunning = true;
        applySpeed = runSpeed;
        anim.SetBool("Running", isRunning);
    }
    public override void Damage(int _damage, Vector3 _targetPos){
        base.Damage(_damage, _targetPos);
        if(!isDead){
            Run(_targetPos);
            //KnockBack();
        }
    }
    void KnockBack(){
        transform.position += transform.forward * Time.deltaTime * KnockBackForce;
    }
}

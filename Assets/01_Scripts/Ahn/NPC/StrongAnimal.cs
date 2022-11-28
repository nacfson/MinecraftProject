using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongAnimal : Animal
{
    public void Chase(Vector3 _targetPos)
    {
        isChasing = true;
        direction = _targetPos;

        currentTime = runTime;
        isWalking = false;
        isRunning = true;
        applySpeed = runSpeed;
        anim.SetBool("Running", isRunning);
    }
    public override void Damage(int _damage, Vector3 _targetPos){
        base.Damage(_damage, _targetPos);
        if(!isDead){
            Chase(_targetPos);
        }
    }
}

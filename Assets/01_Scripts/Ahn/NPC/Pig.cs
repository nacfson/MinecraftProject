using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : WeakAnimal
{
    public void Update()
    {
        //base.Update();
        Debug.Log("보인다");
        if(theViewAngle.View() && !isDead){
            Run(theViewAngle.GetTargetPos());
        }
    }
    private void Wait()
    {
        currentTime = waitTime;
        Debug.Log("대기");
    }
    private void Eat()
    {
        currentTime = waitTime;
        anim.SetTrigger("Eat");
        Debug.Log("풀뜯기");
    }
    private void Peek()
    {
        currentTime = waitTime;
        anim.SetTrigger("Peek");
        Debug.Log("두리번");
    }
    protected override void Reset()
    {
        base.Reset();
        RandomAction();
    }
    private void RandomAction()
    {
        RandomSound();
        int _random = Random.Range(0, 4);

        if(_random == 0)
            TryWalk();
        else if(_random == 1)
            Eat();
        else if(_random == 2)
            Peek();
        else if(_random == 3)
            Wait();
    }
}

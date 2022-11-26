using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : WeakAnimal
{
    
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

<<<<<<< HEAD
        if(_random == 0)
            TryWalk();
        else if(_random == 1)
            Eat();
        else if(_random == 2)
            Peek();
        else if(_random == 3)
            Wait();
=======
        currentTime = runTime;
        isWalking = false;
        isRunning = true;
        applySpeed = runSpeed;
        anim.SetBool("Running", isRunning);
    }
    public void Damage(int _damage, Vector3 _targetPos)
    {
        if(!isDead){
            hp -= _damage;
            SoundManager.instance.SFXPlay("SoundObject", "classic_hurt");
            if (hp <= 0)
            {
                Dead();
                return;
            }

            PlaySE(sound_pig_Hurt);
            anim.SetTrigger("Hurt");
            Run(_targetPos);
        }
    }
    private void Dead(){
        PlaySE(sound_pig_Dead);
        isWalking = false;
        isRunning = false;
        isDead = true;
        anim.SetTrigger("Dead");
    }
    private void RandomSound(){
        int _random = Random.Range(0, 3);
        PlaySE(sound_pig_Normal[_random]);
    }
    private void PlaySE(AudioClip _clip){
        theAudio.clip = _clip;
        theAudio.Play();
>>>>>>> main
    }
}

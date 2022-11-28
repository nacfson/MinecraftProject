using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] protected string animalName;
    [SerializeField] protected int hp;

    [SerializeField] protected float walkSpeed;
    [SerializeField] protected float runSpeed;
    [SerializeField] protected float turningSpeed;
    //[SerializeField] protected float KnockBackForce = 250;
    protected float applySpeed;

    protected Vector3 direction;

    protected bool isAction;
    protected bool isWalking;
    protected bool isRunning;
    protected bool isDead;

    [SerializeField] protected float walkTime;
    [SerializeField] protected float waitTime;
    [SerializeField] protected float runTime;
    protected float currentTime;

    //필요한 컴포넌트
    [SerializeField] protected Animator anim;
    [SerializeField] protected Rigidbody rigid;
    [SerializeField] protected BoxCollider boxCol;
    protected AudioSource theAudio;

    [SerializeField] protected AudioClip[] sound_Normal;
    [SerializeField] protected AudioClip sound_Hurt;
    [SerializeField] protected AudioClip sound_Dead;
    void Start()
    {
        theAudio = GetComponent<AudioSource>();
        currentTime = waitTime;
        isAction = true;
    }

    void Update()
    {
        if(!isDead){
            Move();
            Rotation();
            ElapseTime();
        }
    }

    protected void Move()
    {
        if(isWalking || isRunning)
            rigid.MovePosition(transform.position + (transform.forward * applySpeed * Time.deltaTime));
    }
    protected void Rotation()
    {
        if(isWalking || isRunning)
        {
            Vector3 _rotation = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, direction.y, 0f), turningSpeed);
            rigid.MoveRotation(Quaternion.Euler(_rotation));
        }
    }
    protected void ElapseTime()
    {
        if(isAction)
        {
            currentTime -= Time.deltaTime;
            if(currentTime <=0)
            {
                Reset();
            }
        }
    }

    protected virtual void Reset()
    {
        isWalking = false; isRunning = false; isAction = true;
        applySpeed = walkSpeed;
        anim.SetBool("Walking", isWalking); anim.SetBool("Running", isRunning);
        direction.Set(0f, Random.Range(0f, 360f), 0f);
    }

    
    
    protected void TryWalk()
    {
        isWalking = true;
        anim.SetBool("Walking", isWalking);
        currentTime = waitTime;
        applySpeed = walkSpeed;
        Debug.Log("걷기");
    }
    
    public virtual void Damage(int _damage, Vector3 _targetPos)
    {
        if(!isDead){
            hp -= _damage;
            if(hp <= 0)
            {
                Dead();
                return;
            }

            PlaySE(sound_Hurt);
            anim.SetTrigger("Hurt");
        }
    }
    protected void Dead(){
        PlaySE(sound_Dead);
        Debug.Log("체력 0이하");
        isWalking = false;
        isRunning = false;
        isDead = true;
        anim.SetTrigger(nameof(Dead));
    }
    protected void RandomSound(){
        int _random = Random.Range(0, 3);
        PlaySE(sound_Normal[_random]);
    }
    protected void PlaySE(AudioClip _clip){
        theAudio.clip = _clip;
        theAudio.Play();
    }
}

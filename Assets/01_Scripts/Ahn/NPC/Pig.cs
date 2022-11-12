using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour//인프런 5분40초
{
    [SerializeField] private string animalName;
    [SerializeField] private int hp;

    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    private float applySpeed;

    private Vector3 direction;

    private bool isAction;
    private bool isWalking;
    private bool isRunning;

    [SerializeField] private float walkTime;
    [SerializeField] private float waitTime;
    [SerializeField] private float runTime;
    private float currentTime;

    //필요한 컴포넌트
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private BoxCollider boxCol;
    
    void Start()
    {
        currentTime = waitTime;
        isAction = true;
    }

    void Update()
    {
        Move();
        Rotation();
        ElapseTime();
    }

    private void Move()
    {
        if(isWalking || isRunning)
            rigid.MovePosition(transform.position + (transform.forward * applySpeed * Time.deltaTime));
    }
    private void Rotation()
    {
        if(isWalking || isRunning)
        {
            Vector3 _rotation = Vector3.Lerp(transform.eulerAngles, direction, 0.01f);
            rigid.MoveRotation(Quaternion.Euler(_rotation));
        }
    }
    private void ElapseTime()
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

    private void Reset()
    {
        isWalking = false; isRunning = false; isAction = true;
        applySpeed = walkSpeed;
        anim.SetBool("Walking", isWalking); anim.SetBool("Running", isRunning);
        direction.Set(0f, Random.Range(0f, 360f), 0f);
        RandomAction();
    }

    private void RandomAction()
    {
        int _random = Random.Range(0, 4);

        if(_random == 0)
            Wait();
        else if(_random == 1)
            Eat();
        else if(_random == 2)
            Peek();
        else if(_random == 3)
            TryWalk();
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
    private void TryWalk()
    {
        isWalking = true;
        anim.SetBool("Walking", isWalking);
        currentTime = waitTime;
        applySpeed = walkSpeed;
        Debug.Log("걷기");
    }
    private void Run(Vector3 _targetPos)
    {
        direction = Quaternion.LookRotation(transform.position - _targetPos).eulerAngles;

        currentTime = runTime;
        isWalking = false;
        isRunning = true;
        applySpeed = runSpeed;
        anim.SetBool("Running", isRunning);
    }
    public void Damage(int _damage, Vector3 _targetPos)
    {
        hp -= _damage;
        if(hp <= 0)
        {
            Debug.Log("체력 0 이하");
            return;
        }

        anim.SetTrigger("Hurt");
        Run(_targetPos);
    }
}

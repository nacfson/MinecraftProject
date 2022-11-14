using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AgentHP : MonoBehaviour
{
    public AgentManager agentManager;

    public float hp;
    public float maxHP;

    public UnityEvent Hit;

    [SerializeField]
    private float _knockBackValue;

    private void Awake()
    {
        hp = maxHP;
        agentManager = GetComponent<AgentManager>();
        Damaged(10,gameObject);
    }
    public void Damaged(float damage,GameObject obj)
    {
        hp -= damage;
        Hit?.Invoke();
        //obj.GetComponent<Rigidbody>().AddForce(Vector3.back * _knockBackValue);
        //obj.GetComponent<Rigidbody>().AddForce(Vector3. up * _knockBackValue / 2);
        Debug.Log(hp);
        CheckDie();
    }


    void CheckDie()
    {
        if(hp <=0)
        {
            agentManager.agentDrop.DropItem();
            Destroy(gameObject);
        }
    }

}

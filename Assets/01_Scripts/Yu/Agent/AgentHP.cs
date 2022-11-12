using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentHP : MonoBehaviour
{
    public AgentManager agentManager;

    public float hp;
    public float maxHP;

    private void Awake()
    {
        hp = maxHP;
        agentManager = GetComponent<AgentManager>();
    }

    public void Damaged(float damage)
    {
        hp -= damage;
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

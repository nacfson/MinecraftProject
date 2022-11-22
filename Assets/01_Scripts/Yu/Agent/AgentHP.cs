using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AgentHP : MonoBehaviour
{
    public AgentManager agentManager;
    public PlayerController playerController;

    public float hp;
    public float maxHP;
    

    public UnityEvent Hit;
    public PlayerHeartUI playerHeartUI;

    [SerializeField]
    private float _knockBackValue;

    private void Awake()
    {
        hp = maxHP;
        playerHeartUI ??= GameObject.Find("HeartPanel").GetComponent<PlayerHeartUI>();
        Hit.AddListener(() => playerHeartUI.ShowHP());
        agentManager = GetComponent<AgentManager>();
        playerController = GetComponent<PlayerController>();
        //StartCoroutine(FallCoroutine());
        //Damaged(10,gameObject);
    }
    public void Damaged(float damage,GameObject obj)
    {
        hp -= damage;
        Hit?.Invoke();
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
    IEnumerator FallCoroutine()
    {
        float definedTime = 3f;
        float cuurentFallTime = 0f;
        if(playerController._isGronded)
        {

            yield return null;
        }
    }

}

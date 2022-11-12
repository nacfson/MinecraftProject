using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    public AgentDrop agentDrop;
    public AgentHP agentHP;

    private void Awake()
    {
        agentHP = GetComponent<AgentHP>();
        agentDrop = GetComponent<AgentDrop>();
    }
}

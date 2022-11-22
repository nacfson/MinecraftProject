using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentDrop : MonoBehaviour
{
    public Item dropItem;

    public void DropItem()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        if(dropItem != null)
        {
            Instantiate(dropItem, pos, Quaternion.identity);
        }
    }
}

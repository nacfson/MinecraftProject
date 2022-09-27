using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        GetItems();
    }
    void GetItems()
    {
        Collider[] collidersList = Physics.OverlapSphere(transform.position,10f);
        foreach(var item in collidersList)
        {
            if(item.CompareTag("ITEM"))
            {
                GetItemCor(item.gameObject);
            }
        }
    }
    IEnumerator GetItemCor(GameObject obj)
    {
        float temp = 0;
        while(obj.transform.position != this.transform.position)
        {
            Debug.Log("ERROR");
            obj.transform.position = Vector3.Lerp(obj.transform.position,  transform.position,temp);
            temp += Time.deltaTime;
            yield return null;


        }
        Destroy(gameObject);
    }

}

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
        Collider[] collidersList = Physics.OverlapSphere(transform.position,3f);
        foreach(var item in collidersList)
        {
            if(item.gameObject.CompareTag("ITEM"))
            {
                StartCoroutine(GetItemCor(item.gameObject));
            }
        }
    }
    IEnumerator GetItemCor(GameObject obj)
    {
        float temp = 0;

            Debug.Log("ERROR");
            Vector3.Lerp(obj.transform.position,  transform.position,0f);
            temp += Time.deltaTime;
        yield return null;
        
        Destroy(obj);
    }

}

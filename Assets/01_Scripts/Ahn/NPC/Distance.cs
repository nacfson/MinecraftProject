using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    public GameObject Player;
    public GameObject StrongPig;
    public float Dist;

    void Update(){
        Dist = Vector3.Distance(Player.transform.position, StrongPig.transform.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildPig : StrongAnimal
{
    protected override void Update()
    {
        base.Update();
        Debug.Log("보인다");
        if(theViewAngle.View() && !isDead){
            Chase(GetComponent<Distance>().Player.transform.position);
        }
    }
}

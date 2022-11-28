using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildPig : StrongAnimal
{
    protected override void Update()
    {
        base.Update();
        if(theViewAngle.View() && !isDead){
            Chase(theViewAngle.GetTargetPos());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBA2SmiteDamage : BasicDamage
{

    override public void AssginDamage(float givenDamage, Elements givenElement, GameObject source)
    {
        if(TryGetComponent<CCStatus>(out CCStatus cControl)){
            cControl.applyStun(1,true);
        }
        base.AssginDamage(givenDamage, givenElement, source);
        
    }
    // Update is called once per frame

}
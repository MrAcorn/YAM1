using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBA2SmiteDamage : BasicDamage
{

    override public void AssginDamage(float givenDamage, Elements givenElement, GameObject source)
    {
        if(TryGetComponent<CCStatus>(out CCStatus cControl)){
            //change back to 1 sec stun after testing
            cControl.applySlow(1,0.05f);
        }
        base.AssginDamage(givenDamage, givenElement, source);
        
    }
    // Update is called once per frame

}
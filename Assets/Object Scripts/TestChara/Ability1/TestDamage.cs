using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamage : BasicDamage
{

    override public void AssginDamage(float givenDamage, Elements givenElement, GameObject source)
    {
        if(TryGetComponent<CCStatus>(out CCStatus cControl)){
        }
        base.AssginDamage(givenDamage, givenElement, source);
        
    }
    // Update is called once per frame

}
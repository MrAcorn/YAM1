using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAbility1Class : AbilityClass
{
    
    public override void InputCalled()
    {
        ActivateBA1();
    }
    protected virtual void ActivateBA1()
    {
        caller.Call(gameObject.name, "ABA1", 3);
    }
}

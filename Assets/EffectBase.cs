using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBase : MonoBehaviour
{
    public Caller caller; 
    public GameObject source;
    public Component target;

    public virtual void runTrigger(triggers trigType){

    }
}

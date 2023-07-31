using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBase : MonoBehaviour
{
    public CombatStats targetCStats;
    public Caller caller; 
    public GameObject source;
    public Component trigSource;
    public int Allignment = 0;

    public virtual void runTrigger(triggers trigType, CombatStats targetGameObj){}
}

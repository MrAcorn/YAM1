using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseCharater : MonoBehaviour
{
    [SerializeField] protected Caller caller;
    [SerializeField] protected Stats stats;
    [SerializeField] protected CombatStats combatStats;
    [SerializeField] protected KnockDownRespawn knockDR;
    [SerializeField] public HashSet<InputableClass> abilities = new HashSet<InputableClass>();
    
    protected bool dead = true;

    // Update is called once per frame
    protected virtual void Update()
    {
        print("ability size: " + abilities.Count);

        if (knockDR.dead && !dead)
        {
            foreach(var ability in abilities){
                ability.castable = false;
            }
        }

                if (!knockDR.dead && dead)
        {
            foreach(var ability in abilities){
                ability.castable = true;
            }
        }
    }
}

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
    [SerializeField] protected CCStatus ccStatus;
    [SerializeField] protected Rigidbody rb;
    [SerializeField] public MonoBehaviour movement;
    [SerializeField] public HashSet<InputableClass> abilities = new HashSet<InputableClass>();

    
    protected virtual void Start()
    {
        caller = GetComponent<Caller>();
        stats = GetComponent<Stats>();
        ccStatus = GetComponent<CCStatus>();
        rb = GetComponent<Rigidbody>();
        combatStats = GetComponent<CombatStats>();
        knockDR = GetComponent<KnockDownRespawn>();
        Invoke("Alive", 0.25f);
    }

    protected virtual void Dead(){
        if(ccStatus != null){ ccStatus.ClenseCC(); }
            
            foreach(var ability in abilities){
                
                ability.enabled = false;
            }
    }
    protected virtual void Alive(){
            if(ccStatus != null){ ccStatus.ClenseCC(); }
            foreach(var ability in abilities){
                
                ability.enabled = true;
                ability.castable = true;
            }
    }
}

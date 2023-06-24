using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBot : BaseCharater
{
    private InputCollecter inputC;
    private CCStatus ccStatus;
    private Rigidbody rb;
    private GeneralMovement gm;
    
    // Start is called before the first frame update
    void Start()
    {
        caller = GetComponent<Caller>();
        stats = GetComponent<Stats>();
        ccStatus = GetComponent<CCStatus>();
        rb = GetComponent<Rigidbody>();
        combatStats = GetComponent<CombatStats>();
        knockDR = GetComponent<KnockDownRespawn>();

        abilities.Add(GetComponent<DamageBotAbility1>());
    }

    // Update is called once per frame


}

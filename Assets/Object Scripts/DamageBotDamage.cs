using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBotDamage : MonoBehaviour
{
    private Caller caller;
    private InputCollecter inputC;
    private Stats stats;
    private CCStatus ccStatus;
    private CCCounterPlay ccCounterPlay;
    private Rigidbody rb;
    private GeneralMovement gm;
    private CombatStats combatStats;

    public float damage = 10;
    public int element = 0;
    // Start is called before the first frame update
    void Start()
    {
        caller = GetComponent<Caller>();
        inputC = GetComponent<InputCollecter>();
        stats = GetComponent<Stats>();
        ccStatus = GetComponent<CCStatus>();
        ccCounterPlay = GetComponent<CCCounterPlay>();
        rb = GetComponent<Rigidbody>();
        gm = GetComponent<GeneralMovement>();
        combatStats = GetComponent<CombatStats>();

        //

        combatStats.InCombat();
        stats.heath -= damage;
        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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
    private ElementalManager eM;

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
        eM = GetComponent<ElementalManager>();
        //
        int element = Mathf.RoundToInt(Random.Range(0, 7));
        eM.ApplyElement(element, gameObject) ;
        combatStats.InCombat();
        stats.heath -= damage * (1 - stats.defence[element]/100);
        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

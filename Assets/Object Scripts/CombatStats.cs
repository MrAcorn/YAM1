using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum triggers{
    PreDamage, PostDamage
}
public class CombatStats : MonoBehaviour
{
    public Dictionary<EffectBase, triggers> triggerList = new Dictionary<EffectBase, triggers>();
    private Caller caller;
    private InputCollecter inputC;
    private Stats stats;
    private CCStatus ccStatus;
    private Rigidbody rb;
    private GeneralMovement gm;
    

    // Start is called before the first frame update
    public bool inCombat;
    public bool heathRegenOn;
    public bool energyRegenOn;
    public bool stunSheildRegenOn;
    private float timer;
    
    void Start()
    {
        caller = GetComponent<Caller>();
        inputC = GetComponent<InputCollecter>();
        stats = GetComponent<Stats>();
        ccStatus = GetComponent<CCStatus>();
        rb = GetComponent<Rigidbody>();
        gm = GetComponent<GeneralMovement>();

        InvokeRepeating("HeathRegenerating", 0, 0.25f);
        InvokeRepeating("EnergyRegenerating", 0, 0.25f);
        InvokeRepeating("StunSheildRegenerating", 0, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 4)
        {
            inCombat = false;
        }
    }

    public void InCombat()
    {
        timer = 0;
        inCombat = true;
    }
    void HeathRegenerating()
    {
        if (stats.heath < stats.maxHeath && heathRegenOn && !inCombat)
        {
            stats.heath += stats.heathRegen;
        }
    }
    void EnergyRegenerating()
    {
        if (stats.energy < stats.maxEnergy && energyRegenOn && !inCombat)
        {
            stats.energy += stats.energyRegen;
        }
    }
    void StunSheildRegenerating()
    {
        if (stats.stunShield < stats.maxStunShield && stunSheildRegenOn && !inCombat)
        {
            stats.stunShield += stats.stunShieldRegen;
        }
    }

    public int RunTriggers(triggers trigType, Component trigSource){
        int ret = 0;
        foreach (var trigger in triggerList){
            if(trigger.Value == trigType && trigger.Key != null){
                trigger.Key.target = trigSource;
                trigger.Key.runTrigger(trigType);
                ret++;
            }
        }
        ClearTrigList();
        return ret;
    }

    private void ClearTrigList(){
        bool done = true;
        foreach (var trigger in triggerList){
            if(trigger.Key != null){
                triggerList.Remove(trigger.Key);
                done = false;
                break;
            }
        }
        if(!done){ ClearTrigList(); }
    }
}

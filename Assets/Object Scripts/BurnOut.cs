using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnOut : EffectBase
{
    public CCStatus ccS;
    public Stats playerStats;
    protected float ccTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        caller = GetComponent<Caller>();
        source = gameObject;
        ccS = GetComponent<CCStatus>();
        playerStats = GetComponent<Stats>();
        ccTime = playerStats.burnOutTime;
        BurnOutStart();
        Invoke("BurnOutOver",ccTime);
    }
    protected virtual void BurnOutStart(){
        ccS.applySlow(ccTime, playerStats.setSpeed * 0.5f);
        ccS.applySilence(ccTime);
    }
    protected virtual void BurnOutOver(){
        Destroy(this);
    }

}

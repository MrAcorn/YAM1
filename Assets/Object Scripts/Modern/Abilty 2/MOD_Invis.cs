using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOD_Invis : EffectBase
{
    public float time;
    private Component smokeSource;
    private int oldLayer;
    private MeshRenderer render;
    // Start is called before the first frame update
    void OnEnable(){
        caller = GetComponent<Caller>();
        oldLayer = gameObject.layer;
        render = GetComponent<MeshRenderer>();
        render.enabled = false;
        gameObject.layer = 2;
        CombatStats combatS = GetComponent<CombatStats>();
        combatS.triggerList.Add(this, triggers.AllyPostDamage);
    }
    void Update()
    {   
        if(time == 0 && smokeSource != null){
            render.enabled = false;
            gameObject.layer = 2;
        }
        else{
            time -= Time.deltaTime;
            render.enabled = false;
            gameObject.layer = 2;

            if(time < 0){
                CleanDeath();
            }
        } 
    }
    public override void runTrigger(triggers trigType, CombatStats target)
    {
        if(trigType == triggers.AllyPostDamage){
            targetCStats = target; 
            PreDamage();
        }
    }
    void PreDamage(){
        if(trigSource is BasicDamage && time != 0){
            CleanDeath();
        }
    }
    public void TypeOfInvis(float timeGiven, Component dependantTo)
    {
        time = timeGiven;
        smokeSource = dependantTo;

    }
    public void CleanDeath(){
        gameObject.layer = oldLayer;
        render.enabled = true;
        Destroy(this);
    }
}

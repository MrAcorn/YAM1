using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMetalEffect : EffectBase
{
    public float time = -1;
    void Start(){
        caller = GetComponent<Caller>();
        CombatStats combatS = GetComponent<CombatStats>();
        combatS.triggerList.Add(this, triggers.PreDamage);
    }
    public override void runTrigger(triggers trigType)
    {
        if(trigType == triggers.PreDamage){
            PreDamage();
        }
    }
    void PreDamage(){
        if(target is BasicDamage){
            BasicDamage damageInstance = (BasicDamage)target;
            damageInstance.damage = damageInstance.damage * 1.1f;
            caller.Call(this.name, "WaterMetal DamageBuff to: " + damageInstance.damage, 3);
        }
    }

    void Update(){
        if(time != -1 && time < 0){
            Destroy(this);
        }
        else{
            time -= Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSteal : EffectBase
{
    public CombatStats targetCstats;
    public float time = -1;
    void Start(){
        caller = GetComponent<Caller>();
        CombatStats combatS = GetComponent<CombatStats>();
        combatS.triggerList.Add(this, triggers.EnemyPostDamage);
    }
    public override void runTrigger(triggers trigType, CombatStats target)
    {
        //print("lifeSteal called with trigger: " + trigType + " target is: " + target.gameObject.name);
        if(trigType == triggers.EnemyPostDamage){
            targetCstats = target;
            PreDamage();
        }
    }
    void PreDamage(){
        if(trigSource is BasicDamage){
            BasicDamage damageInstance = (BasicDamage)trigSource;
            targetCstats.GetComponent<Stats>().heath += damageInstance.damage * 0.2f;
            caller.Call(this.name, "Suck the soul for: " + damageInstance.damage, 3);
        }
    }
}

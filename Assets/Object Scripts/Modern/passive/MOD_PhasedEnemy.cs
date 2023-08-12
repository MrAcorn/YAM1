using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOD_PhasedEnemy : EffectBase
{
    public MOD_Phased phasedAbili;
    public int phasedStack = 0;
    public float time = -1;
    void Start(){
        caller = GetComponent<Caller>();
        CombatStats combatS = GetComponent<CombatStats>();
        combatS.triggerList.Add(this, triggers.EnemyPreDamage);
    }
    public override void runTrigger(triggers trigType, CombatStats target)
    {
        if(trigType == triggers.EnemyPreDamage){
            targetCStats = target;
            PreDamage();
        }
    }
    void PreDamage(){
        if(trigSource is BasicDamage){
            print("trigger");
            phasedAbili.ApplyPhaseEffect(this);
        }
    }

}

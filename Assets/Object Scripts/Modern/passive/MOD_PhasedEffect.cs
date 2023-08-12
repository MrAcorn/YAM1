using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOD_PhasedEffect : EffectBase
{
    public MOD_Phased phasedAbili;
    void Start(){
        caller = GetComponent<Caller>();
        CombatStats combatS = GetComponent<CombatStats>();
        phasedAbili = GetComponent<MOD_Phased>();
        combatS.triggerList.Add(this, triggers.AllyPreDamage);
    }

        public override void runTrigger(triggers trigType, CombatStats target)
    {
        if(trigType == triggers.AllyPreDamage){
            targetCStats = target; 
            PreDamage();
        }
    }
        void PreDamage(){
        if(trigSource is BasicDamage){
            phasedAbili.ApplyPhaseStack(targetCStats.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOD_Phased : InputableClass
{  
    public List<GameObject> phasedTargets = new List<GameObject>();
    public Elements currentPhase = Elements.Water;
    public CombatStats cStats;
    protected override void Start(){
        cStats = GetComponent<CombatStats>();
        gameObject.AddComponent<MOD_PhasedEffect>();
        stats = GetComponent<Stats>();
        caller = GetComponent<Caller>();
        //base.Start();
    }

    public MOD_Phased ApplyPhaseStack(GameObject target){
            MOD_PhasedEnemy enemy;
            if(target.GetComponent<MOD_PhasedEnemy>() == null){
                (enemy = target.AddComponent<MOD_PhasedEnemy>()).phasedStack++;
            }
            else{
                (enemy = target.GetComponent<MOD_PhasedEnemy>()).phasedStack++;
            }
            enemy.phasedAbili = this;

    return this;
    }

    public MOD_Phased ApplyPhaseEffect(MOD_PhasedEnemy enemy){

        if(enemy.phasedStack >= 3){
            enemy.gameObject.GetComponent<ElementalManager>().ApplyElement(currentPhase, this.gameObject);
            PhaseShift();
            enemy.phasedStack -= 3;
        }
        if(enemy.phasedStack == 0)
            Destroy(enemy);
        return this;
    }

    public void PhaseShift(){
        if(currentPhase == Elements.Water) currentPhase = Elements.Metal;
        else currentPhase = Elements.Water;
    }
}

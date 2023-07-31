using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMetalEffect : EffectBase
{
    public float time = -1;
    void Start()
    {
        caller = GetComponent<Caller>();
        CombatStats combatS = GetComponent<CombatStats>();
        combatS.triggerList.Add(this, triggers.EnemyPreDamage);
    }
    public override void runTrigger(triggers trigType, CombatStats target)
    {
        if (trigType == triggers.EnemyPreDamage)
        {
            PreDamage();
        }
    }
    void PreDamage()
    {
        if (trigSource is BasicDamage)
        {
            BasicDamage damageInstance = (BasicDamage)trigSource;
            damageInstance.damage = damageInstance.damage * 1.5f;
            caller.Call(this.name, "WaterMetal DamageBuff to: " + damageInstance.damage, 3);
        }
    }

    void Update()
    {
        if (time != -1)
        {
            if (time < 0)
            {
                Destroy(this);
            }
            else
            {
                time -= Time.deltaTime;
            }
        }

    }
}

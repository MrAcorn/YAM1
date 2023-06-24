using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyDamage : BasicDamage
{

    // Start is called before the first frame update

    
    public override void AssginDamage(float givenDamage, int givenElement, GameObject source)
    {
        damage += givenDamage;
        int hold = Random.Range(0, 7);
        element = hold;
        eM.ApplyElement(element, gameObject);
        combatStats.InCombat();
        stats.heath -= damage * (1 - stats.defence[element] / 100);
        Destroy(this);
    }
}



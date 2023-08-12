using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyDamage : BasicDamage
{

    // Start is called before the first frame update

    
    public override void AssginDamage(float givenDamage, Elements givenElement, GameObject source)
    {
        damage += givenDamage;
        //int hold = Random.Range(0, 7);
        //element = (Elements)hold;
        //eM.ApplyElement((Elements)element, gameObject);
        eM.ApplyElement(Elements.Metal, gameObject);
        eM.ApplyElement(Elements.Water, gameObject);
        base.AssginDamage(givenDamage, Elements.Untaged, source);
    }
}



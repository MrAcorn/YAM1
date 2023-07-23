using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBot : BaseCharater
{

    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        abilities.Add(GetComponent<DamageBotAbility1>());
        abilities.Add(GetComponent<DamageBotAbility2>());
        Invoke("Alive", 0.25f);
    }


}

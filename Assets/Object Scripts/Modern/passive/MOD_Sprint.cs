using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOD_Sprint : Sprint
{
    protected override void Burnt(){
        gameObject.AddComponent<MOD_BurnOut>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOD_BurnOut : BurnOut
{
    protected override void BurnOutStart(){
        ccS.applySilence(ccTime);
    }
}

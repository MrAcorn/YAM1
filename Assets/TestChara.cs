using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChara : BaseCharater
{
    private InputCollecter inputC;
    private GeneralMovement gm;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        abilities.Add(GetComponent<DummyBA1>());
        Invoke("Alive", 0.25f);
    }

    // Update is called once per frame

}

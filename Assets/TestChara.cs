using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChara : BaseCharater
{
    private InputCollecter inputC;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        movement = GetComponent<GeneralMovement>();
        abilities.Add(GetComponent<Sprint>());
        abilities.Add(GetComponent<DummyBA1>());
        abilities.Add(GetComponent<Spark>());
        Invoke("Alive", 0);
    }

    // Update is called once per frame

}

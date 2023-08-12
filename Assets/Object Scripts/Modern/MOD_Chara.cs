using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOD_Chara : BaseCharater
{
    private InputCollecter inputC;
    public bool moving;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        inputC = GetComponent<InputCollecter>();
        movement = GetComponent<GeneralMovement>();
        abilities.Add(GetComponent<MOD_Sprint>());
        abilities.Add(GetComponent<MOD_Ability1>());
        abilities.Add(GetComponent<MOD_SmokeToss>());
        abilities.Add(GetComponent<Spark>());
        Invoke("Alive", 0);
    }
    void Update(){
        if(inputC.Fwrd || inputC.Bwrd || inputC.Lwrd || inputC.Rwrd || inputC.up || inputC.down){
            moving = true;
        }
        else{
            moving = false;
        }
    }
    // Update is called once per frame

}

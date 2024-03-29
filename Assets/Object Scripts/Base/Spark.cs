using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : InputableClass
{
    private InputCollecter inputC;
    private CCStatus ccStatus;
    private Rigidbody rb;
    private GeneralMovement gm;
    private CombatStats combatStats;
    
    //
    public string className;

    [SerializeField] private bool cdOn;
    public List<float> modif = new List<float>();
    // could have used enum for this script...

    // Start is called before the first frame update
    protected override void Start()
    {
        input = 8;
        inputC = GetComponent<InputCollecter>();
        ccStatus = GetComponent<CCStatus>();
        rb = GetComponent<Rigidbody>();
        gm = GetComponent<GeneralMovement>();
        base.Start();
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        cooldown = Mathf.Clamp((cooldown - Time.deltaTime),0, cooldown);
    }
    public override void InputCalled()
    {
        if(cooldown <= 0)
        {
            Invoke((className + "Ablility"), 0);
        }
    }
    public void AssassinAblility()
    {
        int xhold = (inputC.Rwrd ? 1 : 0) - (inputC.Lwrd ? 1 : 0);
        int yhold = (inputC.up ? 1 : 0) - (inputC.down ? 1 : 0);
        int zhold = (inputC.Fwrd ? 1 : 0) - (inputC.Bwrd ? 1 : 0);

        if(castable){
            rb.AddForce(transform.TransformDirection(new Vector3((xhold * modif[0]),(yhold * modif[1]),(zhold * modif[2]))),ForceMode.Impulse);
        }
        else{
            //switch to root after testing
            ccStatus.ClenseCC("stun");
        }
        cooldown = setCooldown * (cdOn ? 1 : 0);
    }
    public void JuggernautAblility()
    {
        for (int i = 0; i < stats.defence.Count; i++)
        {
            stats.defence[i] += modif[0];
        }
        Invoke("EndJuggernaut", modif[1]);

        cooldown = setCooldown * (cdOn ? 1 : 0);
    }
    public void MageAblility()
    {
        //ccStatus.immunized = true;
        Invoke("EndMage", modif[0]);
        cooldown = setCooldown * (cdOn ? 1 : 0);
    }
    public void DiverAblility()
    {
        //ccStatus.NegCleanse();
        Invoke("EndDiver", modif[0]);
        cooldown = setCooldown * (cdOn ? 1 : 0);
    }
    public void ZoneAblility()
    {
        //stats.Shield += (stats.maxHeath * modif[0]);
        Invoke("EndZone", modif[1]);
        cooldown = setCooldown * (cdOn ? 1 : 0);

    }
    public void SupportAblility()
    {
        //not in yet
    }
    public void BruiserAblility()
    {
        modif[2] = ((1 - (stats.heath / stats.maxHeath)) * stats.maxHeath * modif[0]);
        //stats.Shield += modif[2];
        Invoke("EndBruiser", modif[1]);
        cooldown = setCooldown * (cdOn ? 1 : 0);
    }
    public void SpecialistAblility()
    {
        stats.speed += stats.setSpeed * modif[0];
        Invoke("EndSpecialist", modif[1]);
        cooldown = setCooldown * (cdOn ? 1 : 0);
    }

    private void EndJuggernaut()
    {
        for (int i = 0; i < stats.defence.Count; i++)
        {
            stats.defence[i] -= modif[0];
        }
    }
    private void EndMage()
    {
        //ccStatus.immunized = false;
    }
    private void EndDiiver()
    {
        //ccStatus.NegCleanse();
    }
    private void EndZone()
    {
        //stats.Shield -= (stats.maxHeath * modif[0]);
    }
    private void EndBruiser()
    {
        //stats.Shield -= modif[2];
    }
    private void EndSpecialist()
    {
        stats.speed -= stats.setSpeed * modif[0];
    }
}

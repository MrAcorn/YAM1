using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour
{
    private Caller caller;
    private InputCollecter inputC;
    private Stats stats;
    private CCStatus ccStatus;
    private CCCounterPlay ccCounterPlay;
    private Rigidbody rb;
    private GeneralMovement gm;
    private CombatStats combatStats;
    
    //
    public string className;
    public float coolDown;
    public float setCoolDown;
    [SerializeField] private bool cdOn;
    public List<float> modif = new List<float>();
    // should have used enum for this script...

    // Start is called before the first frame update
    void Start()
    {
        caller = GetComponent<Caller>();
        inputC = GetComponent<InputCollecter>();
        stats = GetComponent<Stats>();
        ccStatus = GetComponent<CCStatus>();
        ccCounterPlay = GetComponent<CCCounterPlay>();
        rb = GetComponent<Rigidbody>();
        gm = GetComponent<GeneralMovement>();

        
    }

    // Update is called once per frame
    void Update()
    {
        coolDown = Mathf.Clamp((coolDown - Time.deltaTime),0, coolDown);
        if(coolDown == 0 && inputC.spark)
        {
            Invoke((className + "Ablility"), 0);
        }
    }
    public void AssassinAblility()
    {
        int xhold = (inputC.Rwrd ? 1 : 0) - (inputC.Lwrd ? 1 : 0);
        int yhold = (inputC.up ? 1 : 0) - (inputC.down ? 1 : 0);
        int zhold = (inputC.Fwrd ? 1 : 0) - (inputC.Bwrd ? 1 : 0);

        rb.AddForce(new Vector3((xhold * modif[0]),(yhold * modif[1]),(zhold * modif[2])),ForceMode.Impulse);
        coolDown = setCoolDown * (cdOn ? 1 : 0);
    }
    public void JuggernautAblility()
    {
        for (int i = 0; i < stats.defence.Length; i++)
        {
            stats.defence[i] += modif[0];
        }
        Invoke("EndJuggernaut", modif[1]);

        coolDown = setCoolDown * (cdOn ? 1 : 0);
    }
    public void MageAblility()
    {
        ccStatus.immunized = true;
        Invoke("EndMage", modif[0]);
        coolDown = setCoolDown * (cdOn ? 1 : 0);
    }
    public void DiverAblility()
    {
        ccStatus.NegCleanse();
        Invoke("EndDiver", modif[0]);
        coolDown = setCoolDown * (cdOn ? 1 : 0);
    }
    public void ZoneAblility()
    {
        stats.sheild += (stats.maxHeath * modif[0]);
        Invoke("EndZone", modif[1]);
        coolDown = setCoolDown * (cdOn ? 1 : 0);

    }
    public void SupportAblility()
    {
        //not in yet
    }
    public void BruiserAblility()
    {
        modif[2] = ((1 - (stats.heath / stats.maxHeath)) * stats.maxHeath * modif[0]);
        stats.sheild += modif[2];
        Invoke("EndBruiser", modif[1]);
        coolDown = setCoolDown * (cdOn ? 1 : 0);
    }
    public void SpecialistAblility()
    {
        stats.speed += stats.setSpeed * modif[0];
        Invoke("EndSpecialist", modif[1]);
        coolDown = setCoolDown * (cdOn ? 1 : 0);
    }

    private void EndJuggernaut()
    {
        for (int i = 0; i < stats.defence.Length; i++)
        {
            stats.defence[i] -= modif[0];
        }
    }
    private void EndMage()
    {
        ccStatus.immunized = false;
    }
    private void EndDiiver()
    {
        ccStatus.NegCleanse();
    }
    private void EndZone()
    {
        stats.sheild -= (stats.maxHeath * modif[0]);
    }
    private void EndBruiser()
    {
        stats.sheild -= modif[2];
    }
    private void EndSpecialist()
    {
        stats.speed -= stats.setSpeed * modif[0];
    }
}

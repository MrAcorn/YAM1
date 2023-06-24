using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    private Caller caller;
    private InputCollecter inputC;
    private Stats stats;
    private CCStatus ccStatus;
    private Rigidbody rb;
    private GeneralMovement gm;
    private CombatStats combatStats;

    //
    [SerializeField] private bool sprinting;
    [SerializeField] private bool trigger;
    private float timerHold;
    private float timerHold1;
    public bool consumeEnergy;
    // Start is called before the first frame update
    void Start()
    {
        caller = GetComponent<Caller>();
        inputC = GetComponent<InputCollecter>();
        stats = GetComponent<Stats>();
        ccStatus = GetComponent<CCStatus>();
        rb = GetComponent<Rigidbody>();
        gm = GetComponent<GeneralMovement>();
        combatStats = GetComponent<CombatStats>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        timerHold1 += Time.deltaTime;
        if (inputC.sprint && !trigger && stats.energy > stats.energyRegen)
        {
            stats.energy -= stats.sprintCost * stats.heightCostModifier;
            caller.Call(this.ToString(),"Sprinting", 2);
            sprinting = true;
            stats.speed += stats.sprintSpeed;
        }

        if (sprinting)
        {
            timerHold1 = 0;
            timerHold += Time.deltaTime;
            if (timerHold >= 0.25f)
            {
                timerHold = 0;
                stats.energy -= stats.sprintCost * Mathf.Clamp(stats.heightCostModifier * gm.currentHeight, 1, Mathf.Infinity);

            }

            if(inputC.up && inputC.down)
            {

            }
            else
            {
                if (inputC.up)
                {

                    rb.AddForce(Vector3.up * stats.heightModifier, ForceMode.Acceleration);
                    if (rb.velocity.y < 0.01f)
                    {

                        caller.Call(this.ToString(),"Sprinting UP", 2);
                        stats.energy -= stats.sprintActionCost;
                        rb.AddForce(new Vector3(0, stats.jumpHeight + (Mathf.Clamp(rb.velocity.y, rb.velocity.y, 0) * -stats.jumpConstitution), 0), ForceMode.Impulse);
                        stats.speed += stats.boostConstiution;
                        Invoke("endBoost", 0.3f);
                    }

                }
                if (inputC.down)
                {

                    rb.AddForce(Vector3.down * stats.heightModifier, ForceMode.Acceleration);
                    if (rb.velocity.y > 0.01f)
                    {

                        caller.Call(this.ToString(), "Sprinting DOWN", 2);
                        stats.energy -= stats.sprintActionCost;
                        rb.AddForce(new Vector3(0, -(stats.jumpHeight * 2) + (Mathf.Clamp(rb.velocity.y, 0, rb.velocity.y) * -stats.jumpConstitution), 0), ForceMode.Impulse);
                        stats.speed += stats.boostConstiution;
                        Invoke("endBoost", 0.3f);
                    }

                }
            }
            


            combatStats.energyRegenOn = !consumeEnergy;
        }

        if ((!inputC.sprint || stats.energy <= 0) && sprinting)
        {
            stats.speed -= stats.sprintSpeed;
            caller.Call(this.ToString(), "Stop Sprinting", 2);
            sprinting = false;
        }

        if (timerHold1 > stats.sprintRegenStartUp && consumeEnergy)
        {
            combatStats.energyRegenOn = true;
        }
        trigger = inputC.sprint;


    }
    void endBoost()
    {
        stats.speed -= stats.boostConstiution;
    }

}



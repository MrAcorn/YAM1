using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockDownRespawn : MonoBehaviour
{
    private Caller caller;
    private InputCollecter inputC;
    private Stats stats;
    private CCStatus ccStatus;
    private CCCounterPlay ccCounterPlay;
    private Rigidbody rb;
    private GeneralMovement gm;
    private CombatStats combatStats;
    private Collider col;
    private MeshRenderer meshR;
    //
    private float timer;
    public bool knocked;
    public bool dead;
    private float damageTaken;
    private float healthhold;
    public int knockedDownCounter = 3;
    public Transform respwanPoint;
    private int layerHold;

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
        combatStats = GetComponent<CombatStats>();
        col = GetComponent<BoxCollider>();
        meshR = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthhold != stats.heath)
        {
            
            damageTaken += Mathf.Clamp((healthhold - stats.heath), 0, Mathf.Infinity);
            healthhold = stats.heath;
            if (damageTaken >= stats.knockDownThreshhold)
            {
                KnockedDown();
            }
        }
        
        if(stats.heath <= 0)
        {
            Death();
        }   

    }
    void KnockedDown()
    {
        layerHold = gameObject.layer;
        int downLayer = LayerMask.NameToLayer("Down");
        
        gameObject.layer = downLayer;
        caller.Call(this.ToString(), gameObject.name + " Is Down!", 3);
        damageTaken = 0;
        stats.speed += stats.knockDownSpeed;
        knocked = true;
        meshR.enabled = false;
        
        Invoke("GetUp",stats.knockDownTime);
        knockedDownCounter--;
    }

    void GetUp()
    {
        gameObject.layer = layerHold;
        caller.Call(this.ToString(), gameObject.name + " Is Up!", 3);
        stats.speed -= stats.knockDownSpeed;
        knocked = false;
        meshR.enabled = true;
        
    }

    void Death()
    {
        caller.Call(this.ToString(), gameObject.name + " Is Dead!", 3);
        if (stats.heath <= 0)
        {
            transform.position = respwanPoint.position;
            inputC.enabled = false;
            col.enabled = false;
            meshR.enabled = false;
            dead = true;

            Invoke("Live", stats.deathTimer);
        }

    }

    public void Live()
    {
        damageTaken = 0;
        caller.Call(this.ToString(), gameObject.name + " Is Alive!", 3);
        dead = false;
        transform.position = respwanPoint.position;
        col.enabled = true;
        inputC.enabled = true;
        meshR.enabled = true;
        rb.velocity = Vector3.zero;
        stats.heath = stats.setMaxHeath;
        stats.maxHeath = stats.setMaxHeath;
        stats.energy = stats.setMaxEnergy;
        stats.maxEnergy = stats.setMaxEnergy;
        stats.stunShield = stats.setMaxStunShield;
        stats.maxStunShield = stats.setMaxStunShield;
        stats.speed = stats.setSpeed;
        stats.sprintSpeed = stats.setSprintSpeed;
        stats.heightCostModifier = stats.setHeightCostModifier;
    }
    
    
}

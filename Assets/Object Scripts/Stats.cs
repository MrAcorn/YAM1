using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    //Higer Up Scripts
    private Caller caller;
    private InputCollecter inputC;
    //Hold Stats
    public float heath;
    public float maxHeath;
    public float setMaxHeath;
    public float heathRegen;
    public float energy;
    public float maxEnergy;
    public float setMaxEnergy;
    public float energyRegen;
    public float Shield;
    public float stunShield;
    public float stunShieldRegen;
    public float maxStunShield;
    public float setMaxStunShield;
    public float ultCharge;
    public float maxUltCharge;
    public float coolDownReduction;
    public float speed;
    public float setSpeed;
    public float sprintSpeed;
    public float setSprintSpeed;
    public float sprintRegenStartUp;
    public float sprintCost;
    public float sprintActionCost;
    public float heightCostModifier;
    public float setHeightCostModifier;
    public float heightModifier;
    public float visonRange;
    public float setVisonRange;
    public float level;
    public float levelPoints;
    public float experince;
    public float maxJumps;
    public float jumpHeight;
    public float jumpCD;
    public float jumpConstitution;
    public float boostConstiution;
    // (in order) untaged, fire, water, wood, metal, earth, celestial
    public float[] defence = new float[7];
    public float[] setDefence = new float[7];
    public float[] attack = new float[7];
    public float[] setAttack = new float[7];

    // Start is called before the first frame update
    void Start()
    {
        caller = GetComponent<Caller>();
        inputC = GetComponent<InputCollecter>();

        heath = setMaxHeath;
        maxHeath = setMaxHeath;
        energy = setMaxEnergy;
        maxEnergy = setMaxEnergy;
        stunShield = setMaxStunShield;
        maxStunShield = setMaxStunShield;
        speed = setSpeed;
        sprintSpeed = setSprintSpeed;
        heightCostModifier = setHeightCostModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(heath > maxHeath)
        {
            heath = maxHeath;
        }
        if(energy > maxEnergy)
        {
            energy = maxEnergy;
        }
        if(stunShield > maxStunShield)
        {
            stunShield = maxStunShield;
        }
    }

}

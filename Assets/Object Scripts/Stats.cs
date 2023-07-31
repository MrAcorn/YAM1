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
    public float knockDownThreshhold;
    public float knockDownSpeed;
    public float knockDownTime;
    public float energy;
    public float maxEnergy;
    public float setMaxEnergy;
    public float energyRegen;
    public List<ShieldInstance> Shield = new List<ShieldInstance>();
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
    public float deathTimer;
    public float maxJumps;
    public float jumpHeight;
    public float jumpCD;
    public float jumpConstitution;
    public float boostConstiution;
    public float burnOutTime;
    public List<float> modif = new List<float>(4);
    // (in order) untaged, fire, water, wood, metal, earth, celestial
    public List<float> defence = new List<float>(7);
    public List<float> setDefence = new List<float>(7);
    public List<float> attack = new List<float>(7);
    public List<float> setAttack = new List<float>(7);

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

        //Testing
        //SetSheild(30, 10, this);
        //SetSheild(10, 6, this);
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

        for(int i = 0; i < Shield.Count; i++){
            Shield[i].time -= Time.deltaTime;
            if(Shield[i].time <= 0){
                Shield.RemoveAt(i);
            }
        }

        //print("TotalShield: " + GetTotalShield());
    }
    public Stats TakeDamage(float damage, Elements type, bool ignoreSheild){
        damage = damage * (1 - defence[((int)type)] / 100); 
        if(!ignoreSheild){
            while(damage > 0 && Shield.Count != 0){
                Shield[Shield.Count - 1].value -= damage;
                if(Shield[Shield.Count - 1].value <= 0){
                    damage = -Shield[Shield.Count - 1].value;
                    Shield.RemoveAt(Shield.Count - 1);
                }
                else{
                    damage = 0;
                }
            }
            if(damage > 0){
                heath -= damage;
            }
        } 
        return this;
    }
    public Stats SetSheild(float value, float time, Component source){
        Shield.Add(new ShieldInstance(value, time, source));
        return this;
    }
    public float GetTotalShield(){
        float hold = 0;
        for(int i = 0; i <Shield.Count; i++){
            hold += Shield[i].value;
        }
        return hold;
    }
    public class ShieldInstance{
        public float time;
        public float value;
        public Component source;
        public ShieldInstance(float valueShield, float timeShield, Component sourceShield){
            value = valueShield;
            time = timeShield;
            source = sourceShield;
        }

    }

}

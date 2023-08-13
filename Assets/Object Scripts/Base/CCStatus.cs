using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CCStatus : MonoBehaviour
{
    //Higer Up Scripts
    private BaseCharater character;
    private Caller caller;
    private InputCollecter inputC;
    private Stats stats;
    public List<CCStatus.crowdControl> ccEffects = new List<CCStatus.crowdControl>();
    //Hold condition
    //public Dictionary<string,float> ccStat = new Dictionary<string,float>(){};
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<BaseCharater>();
        caller = GetComponent<Caller>();
        inputC = GetComponent<InputCollecter>();
        stats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < ccEffects.Count; i++)
        {
            CCStatus.crowdControl instance = ccEffects[i];
            instance.stats["timer"] -= Time.deltaTime;
            if(instance.stats["timer"] <= 0){
                instance.clearCC(character);
                ccEffects.Remove(instance);
                i--;
            }
        }
        for(int i = 0; i < ccEffects.Count; i++)
        {
            CCStatus.crowdControl instance = ccEffects[i];
            instance.applyCC(character);
        }
    }

    public void ClenseCC(){
        for(int i = 0; i < ccEffects.Count; i++){
            ccEffects[i].clearCC(character);
            ccEffects.Remove(ccEffects[i]); i--;}
    }
    public void ClenseCC(string status){
        for(int i = 0; i < ccEffects.Count; i++){
        if(ccEffects[i].givenName == status){
            ccEffects[i].clearCC(character);
            ccEffects.Remove(ccEffects[i]); i--;
        }    
        }
    }
    public void ClenseCC(int alainment){
        for(int i = 0; i < ccEffects.Count; i++){
        if(ccEffects[i].alainment == alainment){
            ccEffects[i].clearCC(character);
            ccEffects.Remove(ccEffects[i]); i--;
        }    
        }
    }
    public class crowdControl{
        public int alainment = 0;
        public string givenName;
        public Dictionary<string,float> stats = new Dictionary<string,float>(){};
        public Action<BaseCharater> applyCC;
        public Action<BaseCharater> clearCC;
        public crowdControl( Action<BaseCharater> codeApplyCC, Action<BaseCharater> codeClearCC, float time, string name, int helpful ){
            applyCC = codeApplyCC;
            clearCC = codeClearCC;
            stats.Add("timer", time);
            givenName = name;
            alainment = helpful;
        }

    }

    public crowdControl applyStun(float time, bool applySheild){
        crowdControl hold = new crowdControl(
            (BaseCharater chara) => {
                foreach(var ablilty in chara.abilities){ablilty.castable = false;}
            if(chara.movement != null){chara.movement.enabled = false;}
            if(stats.GetTotalShield() < stats.stunShield){
                stats.stunShield = stats.GetTotalShield();
            }
            },
            (BaseCharater chara) => {
                foreach(var ablilty in chara.abilities){ablilty.castable = true;}
            if(chara.movement != null){chara.movement.enabled = true;}
            },
            time, "stun", -1 );
        stats.SetSheild(stats.stunShield,time,this);
        ccEffects.Add(hold);
        return hold;
        
    }

    public crowdControl applySilence(float time){
        crowdControl hold =new crowdControl(
            (BaseCharater chara) => {
                foreach(var ablilty in chara.abilities){ablilty.castable = false;}
            },
            (BaseCharater chara) => {
                foreach(var ablilty in chara.abilities){ablilty.castable = true;}
            },
            time, "silence", -1 );
        ccEffects.Add(hold);
        return hold;
        
    }

    public crowdControl applySlow(float time, float size){
            size = Mathf.Clamp(stats.speed - size, 0.01f, 1);
            stats.speed -= size;
        crowdControl hold =new crowdControl(
            (BaseCharater chara) => {
            },
            (BaseCharater chara) => {
                stats.speed += size;
            },
            time, "slow", -1 );
        hold.stats.Add("size", size);
        ccEffects.Add(hold);
        return hold;
        
    }

        public crowdControl applySpeed(float time, float size){
            stats.speed += size;
        crowdControl hold =new crowdControl(
            (BaseCharater chara) => {
            },
            (BaseCharater chara) => {
                stats.speed -= size;
            },
            time, "speedBoost", 1 );
        hold.stats.Add("size", size);
        ccEffects.Add(hold);
        return hold;
        
    }
}

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
    public Dictionary<string,float> ccStat = new Dictionary<string,float>(){};
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
        for(int i = 0; i < ccEffects.Count; i++){ccEffects.Remove(ccEffects[i]); i--;}
    }

    public class crowdControl{
        public int freindly = 0;
        public string givenName;
        public Dictionary<string,float> stats = new Dictionary<string,float>(){};
        public Action<BaseCharater> applyCC;
        public Action<BaseCharater> clearCC;
        public crowdControl( Action<BaseCharater> codeApplyCC, Action<BaseCharater> codeClearCC, float time, string name ){
            applyCC = codeApplyCC;
            clearCC = codeClearCC;
            stats.Add("timer", time);
            givenName = name;
        }
        public crowdControl( Action<BaseCharater> codeApplyCC, Action<BaseCharater> codeClearCC, float time, string name, int helpful ){
            applyCC = codeApplyCC;
            clearCC = codeClearCC;
            stats.Add("timer", time);
            givenName = name;
            freindly = helpful;
        }

    }

    public void applyStun(float time){
         ccEffects.Add(new crowdControl(
            (BaseCharater chara) => {foreach(var ablilty in chara.abilities){ablilty.castable = false;}},
            (BaseCharater chara) => {foreach(var ablilty in chara.abilities){ablilty.castable = true;}},
            time, "stun", -1 ));
        
    }


}

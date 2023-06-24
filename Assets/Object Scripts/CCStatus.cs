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
    public HashSet<CCStatus.crowdControl> ccEffects = new HashSet<CCStatus.crowdControl>();
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
        foreach (var instance in ccEffects)
        {
            instance.stats["timer"] -= Time.deltaTime;;
            if(instance.stats["timer"] <= 0){
                instance.clearCC(character);
                ccEffects.Remove(instance);
            }
        }
        foreach (var instance in ccEffects)
        {
            instance.applyCC(character);
        }
    }

    public class crowdControl{
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

    }

    public void applyStun(float time){
        ccEffects.Add(new crowdControl(
            (BaseCharater chara) => {foreach(var ablilty in chara.abilities){ablilty.castable = false;}},
            (BaseCharater chara) => {foreach(var ablilty in chara.abilities){ablilty.castable = true;}},
            time, "stun" ));
    }


}

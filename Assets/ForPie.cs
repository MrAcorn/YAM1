using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ForPie : MonoBehaviour
{
    public Stats stats;
    public Stats monkey;
    public Text txt;
    public CCStatus monkeyCC;
    public CombatStats monkeyEffect;
    public ElementalManager monkeElement; 
    // Update is called once per frame
    void Update()
    {
        string list = "";
        for(int i = 0; i < monkeElement.elementQueue.Count; i++){
            list += monkeElement.elementQueue[i].ToString() + " ";
        }
        for(int i = 0; i < monkeyCC.ccEffects.Count; i++){
            list += monkeyCC.ccEffects[i].name + " ";
        }
        foreach(var effect in monkeyEffect.triggerList){
            if(effect.Key.ToString().Length > 6)
            list += effect.Key.ToString().Substring(6) + ", ";
        }
        txt.text = "This is for you pie, even if i didnt want to do it enjoy the UI \n" + 
        "\nHeath: " + stats.heath +
        "\nEnergy: " + stats.energy + 
        "\nMonkey Heath: " + monkey.heath +
        "\nMonkey Stats: " + list +
        "\nAs bug free as the amozon!";


        
    }
}

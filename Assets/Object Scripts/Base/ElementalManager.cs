using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Elements{
        Untaged, Fire, Water, Wood, Metal, Earth, Celestial
    }
public class ElementalManager : MonoBehaviour
{

    private Caller caller;
    private InputCollecter inputC;
    private Stats stats;
    private CCStatus ccStatus;
    private Rigidbody rb;
    private GeneralMovement gm;
    private CombatStats combatStats;
    private Collider col;
    private MeshRenderer meshR;
    //
    public List<Elements> elementQueue = new List<Elements>();
    public List<GameObject> elementQueueName = new List<GameObject>();
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
        col = GetComponent<BoxCollider>();
        meshR = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(elementQueue.Count >= 2)
        {
            ElementReaction();
        }
    }
    
    public void ApplyElement(Elements type, GameObject source)
    {
        if(type != 0)
        {
            elementQueue.Add(type);
            elementQueueName.Add(source);
            caller.Call(this.ToString(), "Element " + type.ToString() + ", from: " + elementQueueName[0], 3);
        }

    }

    void ElementReaction()
    {
        caller.Call(this.ToString(), "Element " + elementQueue[0].ToString() + " and " + elementQueue[1].ToString() + " consumed.", 3);
        string calling = elementQueue[0] < elementQueue[1] ? elementQueue[0].ToString() + elementQueue[1].ToString() : elementQueue[1].ToString() + elementQueue[0].ToString(); 
        Invoke(calling, 0);
        // call elemental Effect manager useing the the data from the frist 2 spots
        Invoke("DelQueue",0);
    }

    private void WaterMetal(){
        caller.Call(this.ToString(), "WaterMetal Reaction activated!", 3);
        if(GetComponent<WaterMetalEffect>() == null){
        WaterMetalEffect effect = gameObject.AddComponent<WaterMetalEffect>();
        effect.source = elementQueueName[1];
        effect.time = 5;
        }
        else{
            WaterMetalEffect effect = gameObject.GetComponent<WaterMetalEffect>();
            effect.source = elementQueueName[1];
            effect.time = 5;
        }
        

    }

    private void WaterWater(){
        caller.Call(this.ToString(), "WaterWater Reaction activated!", 3);
        if(ccStatus != null){
            ccStatus.applySilence(3);
        }
        

    }

    private void MetalMetal(){
        caller.Call(this.ToString(), "MetalMetal Reaction activated!", 3);
        if(ccStatus != null){
            ccStatus.applyStun(3,true);
        }
        

    }
    
    private void DelQueue(){
        elementQueue.RemoveAt(1);
        elementQueue.RemoveAt(0);
        elementQueueName.RemoveAt(1);
        elementQueueName.RemoveAt(0);
    }
}
